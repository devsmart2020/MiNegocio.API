using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class TipoEquipoRepository : ITipoEquipoRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public TipoEquipoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
       
        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbtipoequipo.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbtipoequipo.Remove(entity);
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
            return await _contextcyj.Tbtipoequipo.AnyAsync(x => x.IdTipoEquipo == id);
        }

        public async Task<IEnumerable<Tbtipoequipo>> Get()
        {
            var entities = await _contextcyj.Tbtipoequipo.ToListAsync();
            return entities;
        }

        public async Task<Tbtipoequipo> GetById(int id)
        {
            var entity = await _contextcyj.Tbtipoequipo.FindAsync(id);
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
            await _contextcyj.Tbtipoequipo.AddAsync(entity);
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

        public async Task<Tbtipoequipo> Put(int id, Tbtipoequipo entity)
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
