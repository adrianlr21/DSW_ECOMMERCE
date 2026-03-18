using API.DTO;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {


        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }


        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
        {

            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _ventaService.Registrar(modelo);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }



    }
}
