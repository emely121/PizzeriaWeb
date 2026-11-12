using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int RolId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Activo { get; set; }

    public short IntentosFallidos { get; set; }

    public DateTime? BloqueadoHasta { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public virtual ICollection<Caja> CajaUsuarioAperturas { get; set; } = new List<Caja>();

    public virtual ICollection<Caja> CajaUsuarioCierres { get; set; } = new List<Caja>();

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Desperdicio> Desperdicios { get; set; } = new List<Desperdicio>();

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<FlujoCaja> FlujoCajas { get; set; } = new List<FlujoCaja>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<LogAuditorium> LogAuditoria { get; set; } = new List<LogAuditorium>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Role Rol { get; set; } = null!;

    public virtual ICollection<TokensRecuperacion> TokensRecuperacions { get; set; } = new List<TokensRecuperacion>();
}
