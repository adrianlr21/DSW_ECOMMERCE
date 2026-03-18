using API.DTO;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {

            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA")
                    buscar = "";

                response.Correcto = true;
                response.Resultado = await _productoService.Listar(buscar);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Catalogo/{categoria}/{buscar?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {

            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos")
                    categoria = "";

                if (buscar == "NA")
                    buscar = "";

                response.Correcto = true;
                response.Resultado = await _productoService.Categoria(categoria, buscar);
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

            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _productoService.Obtener(id);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {

            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _productoService.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.Correcto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {

            var response = new ResponseDTO<bool>();

            try
            {
                response.Correcto = true;
                response.Resultado = await _productoService.Editar(modelo);
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
                response.Resultado = await _productoService.Eliminar(id);
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
