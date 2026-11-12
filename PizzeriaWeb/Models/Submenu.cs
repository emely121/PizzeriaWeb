using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Submenu
{
    public int Id { get; set; }

    public int ModuloId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Ruta { get; set; }

    public short Orden { get; set; }

    public bool Activo { get; set; }

    public virtual Modulo Modulo { get; set; } = null!;

    public virtual ICollection<PermisosRol> PermisosRols { get; set; } = new List<PermisosRol>();
}
