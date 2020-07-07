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
        private readonly soport43_minegocioContext _context;

        public TipoReporteRepository(soport43_minegocioContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbtiporeporte.FindAsync(id);
            if (entity != null)
            {
                _context.Tbtiporeporte.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tbtiporeporte.AnyAsync(x => x.IdTipoReporte == id);

        }

        public async Task<IEnumerable<Tbtiporeporte>> Get()
        {
            var entities = await _context.Tbtiporeporte.ToListAsync();
            return entities;
        }

        public async Task<Tbtiporeporte> GetById(int id)
        {
            var entity = await _context.Tbtiporeporte.FindAsync(id);
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
            await _context.Tbtiporeporte.AddAsync(entity);
            var query = await _context.SaveChangesAsync();
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
            _context.Entry(entity).State = EntityState.Modified;
            var query = await _context.SaveChangesAsync();
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
