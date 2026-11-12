using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string UnidadMedida { get; set; } = null!;

    public decimal StockMinimo { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Desperdicio> Desperdicios { get; set; } = new List<Desperdicio>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
