using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public string MetodoPago { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Referencia { get; set; }

    public DateTime FechaPago { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
