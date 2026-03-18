using API.DTO;
using API.Models;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementaciones
{
    public class ProductoService : IProductoService
    {

        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;


        public ProductoService(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> Categoria(string categoria, string buscar)
        {
            try
            {
                var consultar = _productoRepository.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consultar.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var obModelo = _mapper.Map<Producto>(modelo);
                var rspModelo = await _productoRepository.Crear(obModelo);

                if (rspModelo.IdProducto != 0)
                {
                    return _mapper.Map<ProductoDTO>(rspModelo);
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

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var consultar = _productoRepository.Consultar(p => p.IdProducto == modelo.IdProducto);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    fromBDModelo.Nombre = modelo.Nombre;
                    fromBDModelo.Descripcion = modelo.Descripcion;
                    fromBDModelo.IdCategoria = modelo.IdCategoria;
                    fromBDModelo.Precio = modelo.Precio;
                    fromBDModelo.PrecioOferta = modelo.PrecioOferta;
                    fromBDModelo.Cantidad = modelo.Cantidad;
                    fromBDModelo.Imagen = modelo.Imagen;

                    var respuesta = await _productoRepository.Editar(fromBDModelo);

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
                var consultar = _productoRepository.Consultar(p => p.IdProducto == id);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    var respuesta = await _productoRepository.Eliminar(fromBDModelo);
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

        public async Task<List<ProductoDTO>> Listar(string buscar)
        {
            try
            {
                var consultar = _productoRepository.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()));

                consultar = consultar.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consultar.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            try
            {
                var consultar = _productoRepository.Consultar(p => p.IdProducto == id);
                consultar = consultar.Include(c => c.IdCategoriaNavigation);
                var fromBDModelo = await consultar.FirstOrDefaultAsync();

                if (fromBDModelo != null)
                {
                    return _mapper.Map<ProductoDTO>(fromBDModelo);
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
