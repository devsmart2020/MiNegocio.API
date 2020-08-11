using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class TipoProductoRepository : ITipoProductoRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public TipoProductoRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbtipoproducto.FindAsync(id);
            if (entity != null)
            {
                _context.Tbtipoproducto.Remove(entity);
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
            return await _context.Tbtipoproducto.AnyAsync(x => x.IdTipoProducto == id);

        }

        public async Task<IEnumerable<Tbtipoproducto>> Get()
        {
             var entities = await _context.Tbtipoproducto.ToListAsync();
            return entities;
        }

        public async Task<Tbtipoproducto> GetById(int id)
        {
            var entity = await _context.Tbtipoproducto.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbtipoproducto> Post(Tbtipoproducto entity)
        {
            await _context.Tbtipoproducto.AddAsync(entity);
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

        public async Task<Tbtipoproducto> Put(int id, Tbtipoproducto entity)
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
