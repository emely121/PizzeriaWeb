using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<PermisosRol> PermisosRols { get; set; } = new List<PermisosRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
