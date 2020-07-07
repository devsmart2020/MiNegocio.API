using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class TipoEquipoRepository : ITipoEquipoRepository
    {
        private readonly soport43_minegocioContext _context;

        public TipoEquipoRepository(soport43_minegocioContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbtipoequipo.FindAsync(id);
            if (entity != null)
            {
                _context.Tbtipoequipo.Remove(entity);
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
            return await _context.Tbtipoequipo.AnyAsync(x => x.IdTipoEquipo == id);
        }

        public async Task<IEnumerable<Tbtipoequipo>> Get()
        {
            var entities = await _context.Tbtipoequipo.ToListAsync();
            return entities;
        }

        public async Task<Tbtipoequipo> GetById(int id)
        {
            var entity = await _context.Tbtipoequipo.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbtipoequipo> Post(Tbtipoequipo entity)
        {
            await _context.Tbtipoequipo.AddAsync(entity);
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

        public async Task<Tbtipoequipo> Put(int id, Tbtipoequipo entity)
        {
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
