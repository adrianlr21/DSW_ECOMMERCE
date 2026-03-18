using API.DTO;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {

            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA")
                    buscar = "";

                response.Correcto = true;
                response.Resultado = await _categoriaService.Listar(buscar);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {

            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _categoriaService.Obtener(id);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {

            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _categoriaService.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {

            var response = new ResponseDTO<bool>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _categoriaService.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {

            var response = new ResponseDTO<bool>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _categoriaService.Eliminar(id);
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
