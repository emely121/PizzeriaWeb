using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwRecetasProducto
{
    public string? Producto { get; set; }

    public string? Ingrediente { get; set; }

    public decimal? Cantidad { get; set; }

    public string? UnidadMedida { get; set; }
}
