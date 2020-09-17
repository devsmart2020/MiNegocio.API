using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IVentaProductoAnulada
    {
        Task<IEnumerable<Tbventaproductoanulada>> Get();
        Task<Tbventaproductoanulada> GetById(Tbventaproductoanulada entity);
        Task<bool> Post(List<Tbventaproductoanulada> entity);
        Task<bool> Put(Tbventaproductoanulada entity);
        Task<bool> Delete(Tbventaproductoanulada entity);
    }
}
