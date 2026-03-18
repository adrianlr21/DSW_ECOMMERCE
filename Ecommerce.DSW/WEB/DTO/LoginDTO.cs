using System.ComponentModel.DataAnnotations;

namespace WEB.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese su correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string? Clave { get; set; }
    }
}
