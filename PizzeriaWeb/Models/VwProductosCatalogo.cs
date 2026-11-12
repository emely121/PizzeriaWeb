using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwProductosCatalogo
{
    public int? ProductoId { get; set; }

    public string? Producto { get; set; }

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Tipo { get; set; }

    public string? ImagenUrl { get; set; }

    public bool? Disponible { get; set; }
}
