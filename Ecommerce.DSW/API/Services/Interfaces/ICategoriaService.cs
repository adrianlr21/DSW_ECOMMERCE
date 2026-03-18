using API.DTO;

namespace API.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> Listar(string buscar);
        Task<CategoriaDTO> Obtener(int id);
        Task<CategoriaDTO> Crear(CategoriaDTO modelo);
        Task<bool> Editar(CategoriaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
