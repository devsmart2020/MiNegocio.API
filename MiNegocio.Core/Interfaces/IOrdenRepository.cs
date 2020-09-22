using MiNegocio.Core.ReportsEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IOrdenRepository<T>
    {
        Task<IEnumerable<T>> Get(T entity);
        Task<T> GetById(T entity);
        Task<T> Post(T entity);
        Task<bool> Put(T entity);
        Task<bool> Delete(T entity);
        Task<OrdenRemisionCliente> RemisionCliente(OrdenRemisionCliente entity);
    }
}
