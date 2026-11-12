using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Compra
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaCompra { get; set; }

    public string? NumeroDocumento { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
