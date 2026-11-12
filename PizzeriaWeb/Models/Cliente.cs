using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public virtual Carrito? Carrito { get; set; }

    public virtual ICollection<Opinione> Opiniones { get; set; } = new List<Opinione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Usuario? Usuario { get; set; }
}
