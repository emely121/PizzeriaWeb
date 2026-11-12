using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwUsuariosRole
{
    public int? UsuarioId { get; set; }

    public string? NombreCompleto { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Rol { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
