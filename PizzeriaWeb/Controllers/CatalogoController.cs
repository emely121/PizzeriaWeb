using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Data;
using PizzeriaWeb.ViewModels;

namespace PizzeriaWeb.Controllers;

[AllowAnonymous]
public class CatalogoController : Controller
{
    private readonly PizzeriaContext _db;

    public CatalogoController(PizzeriaContext db) => _db = db;

    public async Task<IActionResult> Index(string? q, int? categoriaId)
    {
        var termino = string.IsNullOrWhiteSpace(q) ? null : q.Trim().ToLower();

        // Búsqueda y filtro por categoría
        var consulta = ProductosDisponibles();

        if (categoriaId.HasValue)
            consulta = consulta.Where(x => x.CategoriaId == categoriaId.Value);

        if (termino != null)
            consulta = consulta.Where(x => x.Nombre.ToLower().Contains(termino)
                                        || (x.Descripcion != null && x.Descripcion.ToLower().Contains(termino)));

        var productos = await consulta
            .OrderBy(x => x.Categoria)
            .ThenBy(x => x.Nombre)
            .ToListAsync();

        // "Lo más vendido": solo se muestra cuando no hay búsqueda ni filtro
        var masVendidos = new List<ProductoCatalogoItem>();
        if (termino == null && categoriaId == null)
        {
            var ventas = await (from ap in _db.ArticulosPedidos
                                join pe in _db.Pedidos on ap.PedidoId equals pe.Id
                                where pe.Estado != "Cancelado"
                                group ap by ap.ProductoId into g
                                select new { ProductoId = g.Key, Unidades = g.Sum(x => (long)x.Cantidad) })
                               .OrderByDescending(x => x.Unidades)
                               .Take(4)
                               .ToListAsync();

            var ids = ventas.Select(v => v.ProductoId).ToList();
            if (ids.Count > 0)
            {
                var detalle = await ProductosDisponibles().Where(x => ids.Contains(x.Id)).ToListAsync();
                masVendidos = ventas
                    .Join(detalle, v => v.ProductoId, d => d.Id, (v, d) =>
                    {
                        d.UnidadesVendidas = v.Unidades;
                        return d;
                    })
                    .ToList();
            }
        }

        var categorias = await _db.Categorias
            .Where(c => c.Activa)
            .OrderBy(c => c.Nombre)
            .Select(c => new CategoriaFiltroItem { Id = c.Id, Nombre = c.Nombre })
            .ToListAsync();

        return View(new CatalogoViewModel
        {
            Busqueda = q,
            CategoriaId = categoriaId,
            Categorias = categorias,
            Productos = productos,
            MasVendidos = masVendidos
        });
    }

    private IQueryable<ProductoCatalogoItem> ProductosDisponibles() =>
        from p in _db.Productos
        join c in _db.Categorias on p.CategoriaId equals c.Id
        where p.Disponible && c.Activa
        select new ProductoCatalogoItem
        {
            Id = p.Id,
            CategoriaId = p.CategoriaId,
            Nombre = p.Nombre,
            Categoria = c.Nombre,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
            Tipo = p.Tipo,
            ImagenUrl = p.ImagenUrl
        };
}
