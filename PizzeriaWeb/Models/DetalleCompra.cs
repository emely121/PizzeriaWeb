using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class DetalleCompra
{
    public int Id { get; set; }

    public int CompraId { get; set; }

    public int IngredienteId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal CostoUnitario { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Ingrediente Ingrediente { get; set; } = null!;
}
