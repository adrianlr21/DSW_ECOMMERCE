using API.DTO;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }


        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {

            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = _dashboardService.dashboard();
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
