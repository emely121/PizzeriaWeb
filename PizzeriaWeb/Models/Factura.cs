using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Factura
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public string Numero { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
