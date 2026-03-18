using API.DTO;

namespace API.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Listar(string buscar);
        Task<List<ProductoDTO>> Categoria(string categoria, string buscar);
        Task<ProductoDTO> Obtener(int id);
        Task<ProductoDTO> Crear(ProductoDTO modelo);
        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
