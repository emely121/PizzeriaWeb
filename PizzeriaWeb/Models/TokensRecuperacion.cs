using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class TokensRecuperacion
{
    public long Id { get; set; }

    public int UsuarioId { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime FechaExpiracion { get; set; }

    public bool Usado { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
