using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

      

        public ProductoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

       
        public async Task<bool> Delete(string id)
        {
            var entity = await _contextcyj.Tbproducto.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbproducto.Remove(entity);
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
            return await _contextcyj.Tbproducto.AnyAsync(x => x.IdProducto == id);
        }       

        public async Task<IEnumerable<Tbproducto>> Get(Tbproducto entity)
        {
            return await _contextcyj.Tbproducto.ToListAsync();
        }

        public async Task<Tbproducto> GetById(string id)
        {
            var entity = await _contextcyj.Tbproducto.FindAsync(id);
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
            IEnumerable<InventarioListatoReporte> inventarios = await _contextcyj.Tbproducto
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

        public async Task<bool> Post(Tbproducto entity)
        {          
            await _contextcyj.Tbproducto.AddAsync(entity);
            var query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> PostList(List<Tbproducto> entitiesList)
        {            
            if (entitiesList.Count > 0)
            {
               
                await _contextcyj.Tbproducto.AddRangeAsync(entitiesList);               
                var query = await _contextcyj.SaveChangesAsync();
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

        public async Task<bool> Put(Tbproducto entity)
        {          
            _contextcyj.Entry(entity).State = EntityState.Modified;
            var query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
