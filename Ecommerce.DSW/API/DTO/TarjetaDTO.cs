using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Ingrese su titular de la tarjeta")]
        public string? Titular { get; set; }

        [Required(ErrorMessage = "Ingrese su numero de la tarjeta")]
        public string? NumeroT { get; set; }

        [Required(ErrorMessage = "Ingrese su vigencia de la tarjeta")]
        public string? VigenciaT { get; set; }

        [Required(ErrorMessage = "Ingrese su cvv de la tarjeta")]
        public string? CVV { get; set; }
    }
}
