using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using WEB.DTO;
using WEB.Service.Interfaces;

namespace WEB.Service.Implementaciones
{
    public class CarritoService : ICarritoService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private SweetAlertService _swtAlertService;

        public CarritoService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, SweetAlertService swtAlertService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _swtAlertService = swtAlertService;
        }

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                if (carrito == null)
                {
                    carrito = new List<CarritoDTO>();
                }


                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == modelo.Producto.IdProducto);

                if (encontrado != null)
                {
                    carrito.Remove(encontrado);
                }


                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);


                if (encontrado != null)
                {
                   await _swtAlertService.FireAsync("Producto fue actualizado en carrito");
                }
                else
                {
                    await _swtAlertService.FireAsync("Producto fue agrwgado en carrito");
                }

                MostrarItems.Invoke();
            }
            catch
            {
                await _swtAlertService.FireAsync("No se logró agregar en carrito");

            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
            {
                carrito = new List<CarritoDTO>();
            }
            return carrito;
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if (elemento != null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }
                }
            }
            catch
            {

            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}
