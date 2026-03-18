using API.DTO;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services.Implementaciones
{
    public class DashboardService : IDashboardService
    {

        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;


        public DashboardService(IVentaRepository ventaRepository, IGenericRepository<Usuario> usuarioRepository, IMapper mapper, IGenericRepository<Producto> productoRepository)
        {
            _ventaRepository = ventaRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _productoRepository = productoRepository;
        }


        public string Ingresos()
        {
            var consulta = _ventaRepository.Consultar();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        public int Ventas()
        {
            var consulta = _ventaRepository.Consultar();
            int total = consulta.Count();
            return total;
        }

        public int Clientes()
        {
            var consulta = _usuarioRepository.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        public int Productos()
        {
            var consulta = _productoRepository.Consultar();
            int total = consulta.Count();
            return total;
        }



        public DashboardDTO dashboard()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngreso = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos(),
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
