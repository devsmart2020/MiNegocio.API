using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IPerfilRepository
    {
        Task<IEnumerable<Tbperfil>> GetPerfils();
        Task<Tbperfil> GetPerfil(Tbperfil entity);
        
    }
}
