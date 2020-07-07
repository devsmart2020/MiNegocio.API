using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IFormaPagoRepository
    {
        Task<IEnumerable<Tbformapago>> Get();
        Task<Tbformapago> Post(Tbformapago entity);
        Task<Tbformapago> GetById(int id);
        Task<Tbformapago> Put(int id, Tbformapago entity);
        Task<bool> Delete(int id);
    }
}
