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
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public VentaProductoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }       

        public async Task<int> CantidadEquiposEnDetalle(Tbventaanulada tbventaanulada)
        {
            return await _contextcyj.Tbproducto
                .Where(x => x.IdTipoProducto.Equals(2))
                .CountAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbventaproducto.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbventaproducto.Remove(entity);
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
            return await _contextcyj.Tbventaproducto.AnyAsync(x => x.IdVenta == id);

        }

        public async Task<IEnumerable<Tbventaproducto>> Get()
        {
            var entities = await _contextcyj.Tbventaproducto.ToListAsync();
            return entities;
        }

        public async Task<Tbventaproducto> GetById(int id)
        {
            var entity = await _contextcyj.Tbventaproducto.FindAsync(id);
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
                await _contextcyj.Tbventaproducto.AddAsync(entity[i]);
                //Descontar de inventario
                int cantidad = entity[i].Cantidad;
                Tbproducto producto = await (from p in _contextcyj.Tbproducto
                                             where p.IdProducto == entity[i].IdProducto
                                             select p).FirstOrDefaultAsync();
                producto.Existencia = producto.Existencia - cantidad;
                var descuenta = await _contextcyj.SaveChangesAsync();
            }
            int query = await _contextcyj.SaveChangesAsync();           
            return true;
        }

        public async Task<Tbventaproducto> Put(int id, Tbventaproducto entity)
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
