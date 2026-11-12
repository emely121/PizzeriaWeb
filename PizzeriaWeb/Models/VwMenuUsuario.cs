using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwMenuUsuario
{
    public int? UsuarioId { get; set; }

    public int? ModuloId { get; set; }

    public string? Modulo { get; set; }

    public string? Icono { get; set; }

    public short? ModuloOrden { get; set; }

    public int? SubmenuId { get; set; }

    public string? Submenu { get; set; }

    public string? Ruta { get; set; }

    public short? SubmenuOrden { get; set; }

    public bool? PuedeConsultar { get; set; }

    public bool? PuedeInsertar { get; set; }

    public bool? PuedeEditar { get; set; }

    public bool? PuedeEliminar { get; set; }
}
