using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly soport43_minegocioContext _context;
        public ClienteRepository(soport43_minegocioContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _context.Tbcliente.FindAsync(id);
            if (entity != null)
            {
                _context.Tbcliente.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(string id)
        {
            return await _context.Tbcliente.AnyAsync(x => x.DocId == id);

        }

        public async Task<IEnumerable<Tbcliente>> Get()
        {
            var entities = await _context.Tbcliente.ToListAsync();
            return entities;
        }

        public async Task<Tbcliente> GetById(string id)
        {
            var entity = await _context.Tbcliente.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbcliente> Post(Tbcliente entity)
        {
            await _context.Tbcliente.AddAsync(entity);
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

        public async Task<Tbcliente> Put(string id, Tbcliente entity)
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
