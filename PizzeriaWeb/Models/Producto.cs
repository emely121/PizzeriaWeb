using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string Tipo { get; set; } = null!;

    public string? ImagenUrl { get; set; }

    public bool Disponible { get; set; }

    public virtual ICollection<ArticulosCarrito> ArticulosCarritos { get; set; } = new List<ArticulosCarrito>();

    public virtual ICollection<ArticulosPedido> ArticulosPedidos { get; set; } = new List<ArticulosPedido>();

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
