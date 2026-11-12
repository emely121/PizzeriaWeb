using System;
using System.Collections.Generic;

namespace PizzeriaWeb.Models;

public partial class Caja
{
    public int Id { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioAperturaId { get; set; }

    public int? UsuarioCierreId { get; set; }

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public decimal MontoInicial { get; set; }

    public decimal? MontoEsperado { get; set; }

    public decimal? MontoCierre { get; set; }

    public decimal? Diferencia { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<FlujoCaja> FlujoCajas { get; set; } = new List<FlujoCaja>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario UsuarioApertura { get; set; } = null!;

    public virtual Usuario? UsuarioCierre { get; set; }
}
