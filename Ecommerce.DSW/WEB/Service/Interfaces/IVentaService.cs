using WEB.DTO;

namespace WEB.Service.Interfaces
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
