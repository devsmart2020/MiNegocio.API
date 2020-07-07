using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IEstadoCompraRepository
    {
        Task<IEnumerable<Tbestadocompra>> Get();
        Task<Tbestadocompra> Post(Tbestadocompra entity);
        Task<Tbestadocompra> GetById(int id);
        Task<Tbestadocompra> Put(int id, Tbestadocompra entity);
        Task<bool> Delete(int id);
        
    }
}
