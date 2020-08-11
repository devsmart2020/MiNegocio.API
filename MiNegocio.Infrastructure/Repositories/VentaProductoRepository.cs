using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class VentaProductoRepository : IVentaProductoRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public VentaProductoRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbventaproducto.FindAsync(id);
            if (entity != null)
            {
                _context.Tbventaproducto.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tbventaproducto.AnyAsync(x => x.IdVenta == id);

        }

        public async Task<IEnumerable<Tbventaproducto>> Get()
        {
            var entities = await _context.Tbventaproducto.ToListAsync();
            return entities;
        }

        public async Task<Tbventaproducto> GetById(int id)
        {
            var entity = await _context.Tbventaproducto.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Post(List<Tbventaproducto> entity)
        {
            for (int i = 0; i < entity.Count; i++)
            {
                await _context.Tbventaproducto.AddAsync(entity[i]);
                //Descontar de inventario
                int cantidad = entity[i].Cantidad;
                Tbproducto producto = await (from p in _context.Tbproducto
                                             where p.IdProducto == entity[i].IdProducto
                                             select p).FirstOrDefaultAsync();
                producto.Existencia = producto.Existencia - cantidad;
                var descuenta = await _context.SaveChangesAsync();
            }
            int query = await _context.SaveChangesAsync();           
            return true;
        }

        public async Task<Tbventaproducto> Put(int id, Tbventaproducto entity)
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
