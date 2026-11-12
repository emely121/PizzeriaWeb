using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Inventario
{
    public int Id { get; set; }

    public int SucursalId { get; set; }

    public int IngredienteId { get; set; }

    public decimal Existencia { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public virtual Ingrediente Ingrediente { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
