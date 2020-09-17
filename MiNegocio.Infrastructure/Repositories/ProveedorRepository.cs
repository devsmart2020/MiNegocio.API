using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;       

        public ProveedorRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

       

        public async Task<bool> Delete(string id)
        {
            var entity = await _contextcyj.Tbproveedor.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbproveedor.Remove(entity);
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
            return await _contextcyj.Tbproveedor.AnyAsync(x => x.IdProveedor == id);
        }

        public async Task<IEnumerable<Tbproveedor>> Get()
        {
            var entities = await _contextcyj.Tbproveedor.ToListAsync();
            return entities;
        }

        public async Task<Tbproveedor> GetById(string id)
        {
            var entity = await _contextcyj.Tbproveedor.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbproveedor> Post(Tbproveedor entity)
        {
            await _contextcyj.Tbproveedor.AddAsync(entity);
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

        public async Task<Tbproveedor> Put(string id, Tbproveedor entity)
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
