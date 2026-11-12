using System.ComponentModel.DataAnnotations;

namespace PizzeriaWeb.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Ingrese su usuario o correo.")]
    [Display(Name = "Usuario o correo")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese su contraseña.")]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
}
