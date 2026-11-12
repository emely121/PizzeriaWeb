using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class LogAuditorium
{
    public long Id { get; set; }

    public int? UsuarioId { get; set; }

    public string Accion { get; set; } = null!;

    public string TablaAfectada { get; set; } = null!;

    public string? RegistroId { get; set; }

    public string? Detalle { get; set; }

    public DateTime FechaHora { get; set; }

    public string? DireccionIp { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
