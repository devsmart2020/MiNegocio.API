using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class FormaPagoRepository : IFormaPagoRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public FormaPagoRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbformapago.FindAsync(id);
            if (entity != null)
            {
                _context.Tbformapago.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Tbformapago>> Get()
        {
            var entities = await _context.Tbformapago.ToListAsync();
            return entities;
        }

        public async Task<Tbformapago> GetById(int id)
        {
            var entity = await _context.Tbformapago.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbformapago> Post(Tbformapago entity)
        {
            await _context.Tbformapago.AddAsync(entity);
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

        public async Task<Tbformapago> Put(int id, Tbformapago entity)
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
