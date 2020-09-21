using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IOrdenRepository<T>
    {
        Task<IEnumerable<Tborden>> Get(T entity);
        Task<T> GetById(T entity);
        Task<bool> Post(T entity);
        Task<bool> Put(T entity);
        Task<bool> Delete(T entity);
    }
}
