using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Modulo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Icono { get; set; }

    public short Orden { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Submenu> Submenus { get; set; } = new List<Submenu>();
}
