using WEB.DTO;

namespace WEB.Service.Interfaces
{
    public interface IProductoService
    {
        Task<ResponseDTO<List<ProductoDTO>>> Listar(string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Categoria(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Obtener(int id);
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
