using WEB.DTO;

namespace WEB.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Listar(string rol, string buscar);
        Task<ResponseDTO<UsuarioDTO>> Obtener(int id);
        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
