using WEB.DTO;

namespace WEB.Service.Interfaces
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Listar(string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
