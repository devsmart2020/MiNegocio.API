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
        private readonly soport43_minegocioContext _context;

        public ProveedorRepository(soport43_minegocioContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _context.Tbproveedor.FindAsync(id);
            if (entity != null)
            {
                _context.Tbproveedor.Remove(entity);
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
            return await _context.Tbproveedor.AnyAsync(x => x.IdProveedor == id);
        }

        public async Task<IEnumerable<Tbproveedor>> Get()
        {
            var entities = await _context.Tbproveedor.ToListAsync();
            return entities;
        }

        public async Task<Tbproveedor> GetById(string id)
        {
            var entity = await _context.Tbproveedor.FindAsync(id);
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
            await _context.Tbproveedor.AddAsync(entity);
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

        public async Task<Tbproveedor> Put(string id, Tbproveedor entity)
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
