using API.DTO;

namespace API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Listar(string rol, string buscar);
        Task<UsuarioDTO> Obtener(int id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
