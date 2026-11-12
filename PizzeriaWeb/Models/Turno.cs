using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Turno
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public int SucursalId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
