using MiNegocio.Core.Entities;
using MiNegocio.Core.ReportsEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<Tbequipo>> Get();
        Task<Tbequipo> Post(Tbequipo entity);
        Task<Tbequipo> GetById(int id);
        Task<Tbequipo> Put(int id, Tbequipo entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<IEnumerable<EquiposxCliente>> EquipoCliente(string idCliente);        
    }
}
