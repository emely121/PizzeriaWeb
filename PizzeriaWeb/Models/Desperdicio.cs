using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Desperdicio
{
    public long Id { get; set; }

    public int SucursalId { get; set; }

    public int IngredienteId { get; set; }

    public int UsuarioId { get; set; }

    public decimal Cantidad { get; set; }

    public string Motivo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Ingrediente Ingrediente { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
