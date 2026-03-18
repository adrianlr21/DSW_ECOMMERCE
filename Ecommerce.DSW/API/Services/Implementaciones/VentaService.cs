using API.DTO;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services.Implementaciones
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;


        public VentaService(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _ventaRepository.Registrar(dbModelo);

                if (ventaGenerada.IdVenta == 0)
                {
                    throw new TaskCanceledException("No se logro registrar");
                }

                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
