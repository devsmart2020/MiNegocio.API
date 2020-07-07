using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Tbproveedor>> Get();
        Task<Tbproveedor> Post(Tbproveedor entity);
        Task<Tbproveedor> GetById(string id);
        Task<Tbproveedor> Put(string id, Tbproveedor entity);
        Task<bool> Delete(string id);
        Task<bool> Exists(string id);       
    }
}
