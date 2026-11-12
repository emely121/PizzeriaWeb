using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwMasVendido
{
    public int? ProductoId { get; set; }

    public string? Producto { get; set; }

    public string? Categoria { get; set; }

    public long? UnidadesVendidas { get; set; }

    public decimal? Ingresos { get; set; }
}
