using System.ComponentModel.DataAnnotations;

namespace WEB.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre del producto")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese su descripcion del producto")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese su precio del producto")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Ingrese su precio oferta del producto")]
        public decimal? PrecioOferta { get; set; }

        [Required(ErrorMessage = "Ingrese su cantidad del producto")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese su imagen del producto")]
        public string? Imagen { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}
