using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int SucursalId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Puesto { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaContratacion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();

    public virtual Usuario? Usuario { get; set; }
}
