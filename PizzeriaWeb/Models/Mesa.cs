using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Mesa
{
    public int Id { get; set; }

    public int SucursalId { get; set; }

    public int Numero { get; set; }

    public short Capacidad { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Sucursale Sucursal { get; set; } = null!;
}
