using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface ITipoProductoRepository
    {
        Task<IEnumerable<Tbtipoproducto>> Get();
        Task<Tbtipoproducto> Post(Tbtipoproducto entity);
        Task<Tbtipoproducto> GetById(int id);
        Task<Tbtipoproducto> Put(int id, Tbtipoproducto entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}
