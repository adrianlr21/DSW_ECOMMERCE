using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Utilidades
{
    public class AutoMapperProfile: Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();


            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();


            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>().ForMember(destino => destino.IdCategoriaNavigation, opt => opt.Ignore());


            CreateMap<DetalleVenta, DetalleVentaDTO>();
            CreateMap<DetalleVentaDTO, DetalleVenta>();


            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();
        }
    }
}
