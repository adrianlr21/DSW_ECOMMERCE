using System.Linq.Expressions;

namespace API.Repository.Interfaces
{
    public interface IGenericRepository<TModelo> where TModelo : class
    {
        IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null);
        Task<TModelo> Crear(TModelo modelo);
        Task<bool> Editar(TModelo modelo);
        Task<bool> Eliminar(TModelo modelo);
    }
}
