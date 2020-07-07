using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IReporteRepository
    {
        Task<IEnumerable<Tbreportes>> Get();
        Task<Tbreportes> Post(Tbreportes entity);
        Task<Tbreportes> GetById(int id);
        Task<Tbreportes> Put(int id, Tbreportes entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<List<Tbreportes>> GetByIdTr(int idTipoReporte);
    }
}
