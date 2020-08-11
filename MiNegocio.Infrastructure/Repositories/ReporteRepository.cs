using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public ReporteRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbreportes.FindAsync(id);
            if (entity != null)
            {
                _context.Tbreportes.Remove(entity);
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
            return await _context.Tbreportes.AnyAsync(x => x.IdReporte == id);

        }

        public async Task<IEnumerable<Tbreportes>> Get()
        {
            var entities = await _context.Tbreportes.ToListAsync();
            return entities;
        }

        public async Task<Tbreportes> GetById(int id)
        {
            var entity = await _context.Tbreportes.FindAsync(id);
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
            return await _context.Tbreportes
                .Where(x => x.IdTipoReporte == idTipoReporte)
                .ToListAsync();
        }

        public async Task<Tbreportes> Post(Tbreportes entity)
        {
            await _context.Tbreportes.AddAsync(entity);
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

        public async Task<Tbreportes> Put(int id, Tbreportes entity)
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
