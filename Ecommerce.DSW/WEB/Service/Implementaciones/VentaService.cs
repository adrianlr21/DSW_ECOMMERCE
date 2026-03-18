using System.Net.Http.Json;
using WEB.DTO;
using WEB.Service.Interfaces;

namespace WEB.Service.Implementaciones
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;

        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", modelo);
            var resultado = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();

            return resultado;
        }
    }
}
