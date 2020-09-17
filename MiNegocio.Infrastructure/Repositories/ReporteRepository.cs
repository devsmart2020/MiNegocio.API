using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

      

        public ReporteRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
       

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbreportes.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbreportes.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _contextcyj.Tbreportes.AnyAsync(x => x.IdReporte == id);

        }

        public async Task<IEnumerable<Tbreportes>> Get()
        {
            var entities = await _contextcyj.Tbreportes.ToListAsync();
            return entities;
        }

        public async Task<Tbreportes> GetById(int id)
        {
            var entity = await _contextcyj.Tbreportes.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Tbreportes>> GetByIdTr(int idTipoReporte)
        {
            return await _contextcyj.Tbreportes
                .Where(x => x.IdTipoReporte == idTipoReporte)
                .ToListAsync();
        }

        public async Task<Tbreportes> Post(Tbreportes entity)
        {
            await _contextcyj.Tbreportes.AddAsync(entity);
            var query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbreportes> Put(int id, Tbreportes entity)
        {
            _contextcyj.Entry(entity).State = EntityState.Modified;
            var query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }
    }
}
