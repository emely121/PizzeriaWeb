using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int MesaId { get; set; }

    public DateTime FechaHora { get; set; }

    public short CantidadPersonas { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Mesa Mesa { get; set; } = null!;
}
