using API.DTO;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementaciones
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var obModelo = _mapper.Map<Categoria>(modelo);
                var rspModelo = await _categoriaRepository.Crear(obModelo);

                if (rspModelo.IdCategoria != 0)
                {
                    return _mapper.Map<CategoriaDTO>(rspModelo);
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


        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var consultar = _categoriaRepository.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    fromBDModelo.Nombre = modelo.Nombre;
                    var respuesta = await _categoriaRepository.Editar(fromBDModelo);

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
                var consultar = _categoriaRepository.Consultar(p => p.IdCategoria == id);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    var respuesta = await _categoriaRepository.Eliminar(fromBDModelo);
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


        public async Task<List<CategoriaDTO>> Listar(string buscar)
        {
            try
            {
                var consultar = _categoriaRepository.Consultar(p =>
                p.Nombre!.ToLower().Contains(buscar.ToLower()));

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consultar.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var consultar = _categoriaRepository.Consultar(p => p.IdCategoria == id);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    return _mapper.Map<CategoriaDTO>(fromBDModelo);
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
