using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwInventarioPorSucursal
{
    public string? Sucursal { get; set; }

    public string? Ingrediente { get; set; }

    public string? UnidadMedida { get; set; }

    public decimal? Existencia { get; set; }

    public decimal? StockMinimo { get; set; }

    public string? EstadoStock { get; set; }
}
