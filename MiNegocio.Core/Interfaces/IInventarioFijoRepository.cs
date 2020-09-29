using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IInventarioFijoRepository
    {
        Task<IEnumerable<Tbinventariofijo>> GetAll(Tbinventariofijo entity);
        Task<Tbinventariofijo> Get(Tbinventariofijo entity);
        Task<bool> Post(Tbinventariofijo entity);
        Task<bool> Put(Tbinventariofijo entity);
        Task<bool> Delete(Tbinventariofijo entity);
    }
}
