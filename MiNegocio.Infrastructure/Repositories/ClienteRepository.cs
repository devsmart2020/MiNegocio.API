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
        private readonly soport43_minegociocyjContext _contextcyj;

     

        public ClienteRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }      

        public async Task<bool> Delete(string id)
        {
            var entity = await _contextcyj.Tbcliente.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbcliente.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(string id)
        {
            return await _contextcyj.Tbcliente.AnyAsync(x => x.DocId == id);

        }

        public async Task<IEnumerable<Tbcliente>> Get()
        {
            var entities = await _contextcyj.Tbcliente.ToListAsync();
            return entities;
        }

        public async Task<Tbcliente> GetById(string id)
        {
            var entity = await _contextcyj.Tbcliente.FindAsync(id);
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
            await _contextcyj.Tbcliente.AddAsync(entity);
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

        public async Task<Tbcliente> Put(string id, Tbcliente entity)
        {
            _contextcyj.Entry(entity).State = EntityState.Modified;
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
