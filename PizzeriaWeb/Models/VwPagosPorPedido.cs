using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwPagosPorPedido
{
    public int? PedidoId { get; set; }

    public string? Cliente { get; set; }

    public decimal? Total { get; set; }

    public decimal? TotalPagado { get; set; }

    public decimal? SaldoPendiente { get; set; }
}
