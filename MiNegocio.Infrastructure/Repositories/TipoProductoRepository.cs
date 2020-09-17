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
        private readonly soport43_minegociocyjContext _contextcyj;
      

        public TipoProductoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
       

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbtipoproducto.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbtipoproducto.Remove(entity);
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
            return await _contextcyj.Tbtipoproducto.AnyAsync(x => x.IdTipoProducto == id);

        }

        public async Task<IEnumerable<Tbtipoproducto>> Get()
        {
             var entities = await _contextcyj.Tbtipoproducto.ToListAsync();
            return entities;
        }

        public async Task<Tbtipoproducto> GetById(int id)
        {
            var entity = await _contextcyj.Tbtipoproducto.FindAsync(id);
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
            await _contextcyj.Tbtipoproducto.AddAsync(entity);
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

        public async Task<Tbtipoproducto> Put(int id, Tbtipoproducto entity)
        {
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
