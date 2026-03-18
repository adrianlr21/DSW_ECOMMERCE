using API.DTO;

namespace API.Services.Interfaces
{
    public interface IVentaService
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);
    }
}
