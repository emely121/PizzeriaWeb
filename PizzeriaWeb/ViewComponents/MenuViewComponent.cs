using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Data;

namespace PizzeriaWeb.ViewComponents;

/// <summary>Menú dinámico: módulos y submenús según los permisos del rol del usuario.</summary>
public class MenuViewComponent : ViewComponent
{
    private readonly PizzeriaContext _db;

    public MenuViewComponent(PizzeriaContext db) => _db = db;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claim = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(claim, out var usuarioId))
            return Content(string.Empty);

        var items = await _db.VwMenuUsuarios
            .Where(m => m.UsuarioId == usuarioId)
            .OrderBy(m => m.ModuloOrden)
            .ThenBy(m => m.SubmenuOrden)
            .ToListAsync();

        return View(items);
    }
}
