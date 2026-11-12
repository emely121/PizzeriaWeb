using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class FlujoCaja
{
    public long Id { get; set; }

    public int CajaId { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int? PedidoId { get; set; }

    public virtual Caja Caja { get; set; } = null!;

    public virtual Pedido? Pedido { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
