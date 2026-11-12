using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class ArticulosCarrito
{
    public int Id { get; set; }

    public int CarritoId { get; set; }

    public int ProductoId { get; set; }

    public short Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Carrito Carrito { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
