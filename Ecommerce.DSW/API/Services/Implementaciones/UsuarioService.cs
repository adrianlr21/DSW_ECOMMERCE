using API.DTO;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;


        public UsuarioService(IGenericRepository<Usuario> usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consultar = _usuarioRepository.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    return _mapper.Map<SesionDTO>(fromBDModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencia");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var obModelo = _mapper.Map<Usuario>(modelo);
                var rspModelo = await _usuarioRepository.Crear(obModelo);

                if (rspModelo.IdUsuario != 0)
                {
                    return _mapper.Map<UsuarioDTO>(rspModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se logro crear");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var consultar = _usuarioRepository.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    fromBDModelo.NombreCompleto = modelo.NombreCompleto;
                    fromBDModelo.Correo = modelo.Correo;
                    fromBDModelo.Clave = modelo.Clave;

                    var respuesta = await _usuarioRepository.Editar(fromBDModelo);

                    if (respuesta)
                    {
                        throw new TaskCanceledException("No se logro editar");
                    }
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consultar = _usuarioRepository.Consultar(p => p.IdUsuario == id);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    var respuesta = await _usuarioRepository.Eliminar(fromBDModelo);
                    if (respuesta)
                    {
                        throw new TaskCanceledException("No se logro eliminar");
                    }
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioDTO>> Listar(string rol, string buscar)
        {
            try
            {
                var consultar = _usuarioRepository.Consultar(p =>
                p.Rol == rol &&
                string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consultar.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var consultar = _usuarioRepository.Consultar(p => p.IdUsuario == id);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    return _mapper.Map<UsuarioDTO>(fromBDModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se logro encontrar coincidencia");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
