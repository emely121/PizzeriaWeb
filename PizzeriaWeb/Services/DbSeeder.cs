using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Data;
using PizzeriaWeb.Models;

namespace PizzeriaWeb.Services;

public static class DbSeeder
{
    /// <summary>
    /// Crea el usuario administrador inicial. La clave se lee de los secretos de usuario
    /// (Seed:AdminPassword); si no existe esa clave, no hace nada.
    /// </summary>
    public static async Task SeedAdminAsync(IServiceProvider services, IConfiguration config)
    {
        var password = config["Seed:AdminPassword"];
        if (string.IsNullOrWhiteSpace(password)) return;

        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PizzeriaContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<PizzeriaContext>>();

        try
        {
            if (await db.Usuarios.AnyAsync(u => u.NombreUsuario.ToLower() == "admin")) return;

            var rolId = await db.Roles
                .Where(r => r.Nombre == "Administrador")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if (rolId == 0)
            {
                logger.LogWarning("No existe el rol Administrador; no se creó el usuario admin.");
                return;
            }

            db.Usuarios.Add(new Usuario
            {
                RolId = rolId,
                NombreCompleto = "Administrador principal",
                NombreUsuario = "admin",
                Correo = "admin@pizzeria.local",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Activo = true
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Usuario admin creado.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "No se pudo crear el usuario administrador inicial.");
        }
    }
}
