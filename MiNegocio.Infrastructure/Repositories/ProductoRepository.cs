using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly soport43_minegociovillegasContext _context;

        public ProductoRepository(soport43_minegociovillegasContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(string id)
        {
            var entity = await _context.Tbproducto.FindAsync(id);
            if (entity != null)
            {
                _context.Tbproducto.Remove(entity);
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
            return await _context.Tbproducto.AnyAsync(x => x.IdProducto == id);
        }

        public async Task<IEnumerable<Tbproducto>> Get()
        {
            var entities = await _context.Tbproducto.ToListAsync();
            return entities;
        }

        public async Task<Tbproducto> GetById(string id)
        {
            var entity = await _context.Tbproducto.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<InventarioListatoReporte>> GetInventarioListado()
        {
            IEnumerable<InventarioListatoReporte> inventarios = await _context.Tbproducto
                .Select(x => new InventarioListatoReporte()
                {
                    IdProducto = x.IdProducto,
                    Producto = x.Producto,
                    Proveedor = x.IdProveedorNavigation.Proveedor,
                    TipoProducto = x.IdTipoProductoNavigation.TipoProducto,
                    Modelo = x.IdModeloNavigation.Modelo,
                    StockMinimo = x.StockMinimo,
                    Existencia = x.Existencia,
                    Costo = x.Costo,
                    VlrVenta = x.VlrVenta,
                    TotalCostoxProducto = x.Existencia * x.Costo
                })
                .OrderBy(x => x.Producto)
                .ToListAsync();

            return inventarios;
        }

        public async Task<Tbproducto> Post(Tbproducto entity)
        {          
            await _context.Tbproducto.AddAsync(entity);
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

        public async Task<bool> PostList(List<Tbproducto> entitiesList)
        {            
            if (entitiesList.Count > 0)
            {
               
                await _context.Tbproducto.AddRangeAsync(entitiesList);               
                var query = await _context.SaveChangesAsync();
                //return true;
                if (query > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<Tbproducto> Put(string id, Tbproducto entity)
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
