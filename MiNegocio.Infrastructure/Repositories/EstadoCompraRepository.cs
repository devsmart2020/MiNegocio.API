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
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public EstadoCompraRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

       
        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbestadocompra.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbestadocompra.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Tbestadocompra>> Get()
        {
            var entities = await _contextcyj.Tbestadocompra.ToListAsync();
            return entities;
        }

        public async Task<Tbestadocompra> GetById(int id)
        {
            var entity = await _contextcyj.Tbestadocompra.FindAsync(id);
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
            await _contextcyj.Tbestadocompra.AddAsync(entity);
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

        public async Task<Tbestadocompra> Put(int id, Tbestadocompra entity)
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
