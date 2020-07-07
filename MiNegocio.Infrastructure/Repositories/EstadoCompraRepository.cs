using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class EstadoCompraRepository : IEstadoCompraRepository
    {
        private readonly soport43_minegocioContext _context;

        public EstadoCompraRepository(soport43_minegocioContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbestadocompra.FindAsync(id);
            if (entity != null)
            {
                _context.Tbestadocompra.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Tbestadocompra>> Get()
        {
            var entities = await _context.Tbestadocompra.ToListAsync();
            return entities;
        }

        public async Task<Tbestadocompra> GetById(int id)
        {
            var entity = await _context.Tbestadocompra.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbestadocompra> Post(Tbestadocompra entity)
        {
            await _context.Tbestadocompra.AddAsync(entity);
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

        public async Task<Tbestadocompra> Put(int id, Tbestadocompra entity)
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
