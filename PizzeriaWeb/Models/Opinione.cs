using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Opinione
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int PedidoId { get; set; }

    public short Calificacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
