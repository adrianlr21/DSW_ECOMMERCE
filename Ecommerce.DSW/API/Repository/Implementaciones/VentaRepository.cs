using API.Models;
using API.Repository.BDContext;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository.Implementaciones
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {

        private readonly DswEcommerceContext _context;


        public VentaRepository(DswEcommerceContext context) : base(context)
        {
            _context = context;
        }



        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaRealizada = new Venta();

            using (var transaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dtv in modelo.DetalleVenta)
                    {
                        Producto productoEncontrado = _context.Productos.Where(p => p.IdProducto == dtv.IdProducto).First();

                        productoEncontrado.Cantidad = productoEncontrado.Cantidad - dtv.Cantidad;
                        _context.Productos.Update(productoEncontrado);
                    }
                    await _context.SaveChangesAsync();
                    await _context.Venta.AddAsync(modelo);
                    await _context.SaveChangesAsync();

                    ventaRealizada = modelo;
                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
            return ventaRealizada;
        }
    }
}
