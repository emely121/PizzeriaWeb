using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class VwEmpleadosTurno
{
    public int? EmpleadoId { get; set; }

    public string? Empleado { get; set; }

    public string? Puesto { get; set; }

    public string? Sucursal { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public string? EstadoTurno { get; set; }
}
