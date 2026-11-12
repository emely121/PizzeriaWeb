using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int SucursalId { get; set; }

    public int? MesaId { get; set; }

    public int? RepartidorId { get; set; }

    public int? UsuarioRegistroId { get; set; }

    public string TipoServicio { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? DireccionEntrega { get; set; }

    public DateTime FechaPedido { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal? Total { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<ArticulosPedido> ArticulosPedidos { get; set; } = new List<ArticulosPedido>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Factura? Factura { get; set; }

    public virtual ICollection<FlujoCaja> FlujoCajas { get; set; } = new List<FlujoCaja>();

    public virtual Mesa? Mesa { get; set; }

    public virtual Opinione? Opinione { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Empleado? Repartidor { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario? UsuarioRegistro { get; set; }
}
