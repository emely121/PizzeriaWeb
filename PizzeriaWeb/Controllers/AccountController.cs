using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Data;
using PizzeriaWeb.ViewModels;

namespace PizzeriaWeb.Controllers;

public class AccountController : Controller
{
    private const int MaxIntentos = 5;
    private static readonly TimeSpan TiempoBloqueo = TimeSpan.FromMinutes(15);

    // Hash ficticio: se verifica cuando el usuario no existe para que el tiempo de
    // respuesta no revele si el usuario está registrado.
    private static readonly string HashFicticio = BCrypt.Net.BCrypt.HashPassword("clave-ficticia");

    private readonly PizzeriaContext _db;

    public AccountController(PizzeriaContext db) => _db = db;

    [HttpGet, AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Panel");

        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        const string errorGenerico = "Usuario o contraseña incorrectos.";
        var login = model.Usuario.Trim().ToLower();

        var usuario = await _db.Usuarios.FirstOrDefaultAsync(u =>
            u.NombreUsuario.ToLower() == login || u.Correo.ToLower() == login);

        if (usuario is null || !usuario.Activo)
        {
            BCrypt.Net.BCrypt.Verify(model.Password, HashFicticio);
            ModelState.AddModelError(string.Empty, errorGenerico);
            return View(model);
        }

        if (usuario.BloqueadoHasta is { } hasta && hasta > DateTime.UtcNow)
        {
            ModelState.AddModelError(string.Empty,
                "Cuenta bloqueada temporalmente por intentos fallidos. Intente más tarde.");
            return View(model);
        }

        if (!BCrypt.Net.BCrypt.Verify(model.Password, usuario.PasswordHash))
        {
            usuario.IntentosFallidos++;
            if (usuario.IntentosFallidos >= MaxIntentos)
            {
                usuario.BloqueadoHasta = DateTime.UtcNow.Add(TiempoBloqueo);
                usuario.IntentosFallidos = 0;
            }
            await _db.SaveChangesAsync();

            ModelState.AddModelError(string.Empty, errorGenerico);
            return View(model);
        }

        usuario.IntentosFallidos = 0;
        usuario.BloqueadoHasta = null;
        usuario.UltimoAcceso = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        var rol = await _db.Roles
            .Where(r => r.Id == usuario.RolId)
            .Select(r => r.Nombre)
            .FirstAsync();

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Name, usuario.NombreUsuario),
            new("NombreCompleto", usuario.NombreCompleto),
            new(ClaimTypes.Role, rol)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            return LocalRedirect(model.ReturnUrl);

        return RedirectToAction("Index", "Panel");
    }

    [HttpPost, Authorize, ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public IActionResult AccessDenied() => View();
}
