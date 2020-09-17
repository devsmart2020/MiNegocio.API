using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class TipoReporteRepository : ITipoReporteRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public TipoReporteRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }      

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbtiporeporte.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbtiporeporte.Remove(entity);
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
            return await _contextcyj.Tbtiporeporte.AnyAsync(x => x.IdTipoReporte == id);

        }

        public async Task<IEnumerable<Tbtiporeporte>> Get()
        {
            var entities = await _contextcyj.Tbtiporeporte.ToListAsync();
            return entities;
        }

        public async Task<Tbtiporeporte> GetById(int id)
        {
            var entity = await _contextcyj.Tbtiporeporte.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbtiporeporte> Post(Tbtiporeporte entity)
        {
            await _contextcyj.Tbtiporeporte.AddAsync(entity);
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

        public async Task<Tbtiporeporte> Put(int id, Tbtiporeporte entity)
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
