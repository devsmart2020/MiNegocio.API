using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface ITipoEquipoRepository
    {
        Task<IEnumerable<Tbtipoequipo>> Get();
        Task<Tbtipoequipo> Post(Tbtipoequipo entity);
        Task<Tbtipoequipo> GetById(int id);
        Task<Tbtipoequipo> Put(int id, Tbtipoequipo entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}
