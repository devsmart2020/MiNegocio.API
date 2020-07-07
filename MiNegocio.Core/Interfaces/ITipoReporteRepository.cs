using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface ITipoReporteRepository
    {
        Task<IEnumerable<Tbtiporeporte>> Get();
        Task<Tbtiporeporte> Post(Tbtiporeporte entity);       
        Task<Tbtiporeporte> GetById(int id);
        Task<Tbtiporeporte> Put(int id, Tbtiporeporte entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}
