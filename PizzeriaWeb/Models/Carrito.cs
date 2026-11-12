using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<ArticulosCarrito> ArticulosCarritos { get; set; } = new List<ArticulosCarrito>();

    public virtual Cliente Cliente { get; set; } = null!;
}
