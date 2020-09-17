using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IVentaAnulada
    {
        Task<IEnumerable<Tbventaanulada>> Get();
        Task<Tbventaanulada> GetById(Tbventaanulada entity);
        Task<bool> Post(Tbventaanulada entity);
        Task<bool> Put(Tbventaanulada entity);
        Task<bool> Delete(Tbventaanulada entity);
    }
}
