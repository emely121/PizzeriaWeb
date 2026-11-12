using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class PermisosRol
{
    public int RolId { get; set; }

    public int SubmenuId { get; set; }

    public bool PuedeConsultar { get; set; }

    public bool PuedeInsertar { get; set; }

    public bool PuedeEditar { get; set; }

    public bool PuedeEliminar { get; set; }

    public virtual Role Rol { get; set; } = null!;

    public virtual Submenu Submenu { get; set; } = null!;
}
