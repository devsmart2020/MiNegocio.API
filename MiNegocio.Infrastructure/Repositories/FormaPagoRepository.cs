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
        private readonly soport43_minegociocyjContext _contextcyj;

      

        public FormaPagoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

       
        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbformapago.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbformapago.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Tbformapago>> Get()
        {
            var entities = await _contextcyj.Tbformapago.ToListAsync();
            return entities;
        }

        public async Task<Tbformapago> GetById(int id)
        {
            var entity = await _contextcyj.Tbformapago.FindAsync(id);
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
            await _contextcyj.Tbformapago.AddAsync(entity);
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

        public async Task<Tbformapago> Put(int id, Tbformapago entity)
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
