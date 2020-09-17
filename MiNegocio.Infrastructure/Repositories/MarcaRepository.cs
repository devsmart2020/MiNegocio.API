using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public MarcaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

       

        public async Task<bool> Delete(int id)
        {
            var marca = await _contextcyj.Tbmarca.FindAsync(id);
            if (marca != null)
            {
                _contextcyj.Tbmarca.Remove(marca);
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
            return await _contextcyj.Tbmarca.AnyAsync(x => x.IdMarca == id);
        }

        public async Task<IEnumerable<Tbmarca>> Get()
        {
            var entities = await _contextcyj.Tbmarca.ToListAsync();
            return entities;
        }

        public async Task<Tbmarca> GetById(int id)
        {
            var entity = await _contextcyj.Tbmarca.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbmarca> Post(Tbmarca entity)
        {
            await _contextcyj.Tbmarca.AddAsync(entity);
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

        public async Task<Tbmarca> Put(int id, Tbmarca entity)
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
