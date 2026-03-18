using System.ComponentModel.DataAnnotations;

namespace WEB.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre completo")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Ingrese su correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña nuevamente")]
        public string? ConfirmarClave { get; set; }
        public string? Rol { get; set; }
    }
}
