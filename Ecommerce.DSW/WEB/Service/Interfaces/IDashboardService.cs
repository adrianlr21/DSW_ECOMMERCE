using WEB.DTO;

namespace WEB.Service.Interfaces
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
