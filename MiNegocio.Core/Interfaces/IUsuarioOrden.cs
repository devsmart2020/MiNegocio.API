using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IUsuarioOrden
    {
        Task<IEnumerable<Tbusuarioorden>> Get();
        Task<Tbusuarioorden> GetById(Tbusuarioorden entity);
        Task<bool> Post(Tbusuarioorden entity);
        Task<bool> Put(Tbusuarioorden entity);
        Task<bool> Delete(Tbusuarioorden entity);
    }
}
