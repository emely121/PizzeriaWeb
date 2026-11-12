using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwVentasDiaria
{
    public DateOnly? Fecha { get; set; }

    public string? Sucursal { get; set; }

    public long? CantidadPedidos { get; set; }

    public decimal? TotalVendido { get; set; }
}
