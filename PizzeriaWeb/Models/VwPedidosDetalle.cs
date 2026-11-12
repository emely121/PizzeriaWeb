using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwPedidosDetalle
{
    public int? PedidoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? Cliente { get; set; }

    public string? Sucursal { get; set; }

    public string? TipoServicio { get; set; }

    public string? Estado { get; set; }

    public string? Producto { get; set; }

    public short? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Importe { get; set; }

    public decimal? Total { get; set; }
}
