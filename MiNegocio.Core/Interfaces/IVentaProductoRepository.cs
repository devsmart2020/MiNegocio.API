using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IVentaProductoRepository
    {
        Task<IEnumerable<Tbventaproducto>> Get();
        Task<bool> Post(List<Tbventaproducto> entity);
        Task<Tbventaproducto> GetById(int id);
        Task<Tbventaproducto> Put(int id, Tbventaproducto entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<int> CantidadEquiposEnDetalle(Tbventaanulada tbventaanulada);
    }
}
