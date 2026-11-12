using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Gasto
{
    public int Id { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioId { get; set; }

    public int? CajaId { get; set; }

    public string Concepto { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateOnly FechaGasto { get; set; }

    public string? Observaciones { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
