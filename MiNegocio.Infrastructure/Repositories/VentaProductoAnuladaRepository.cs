using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class VentaProductoAnuladaRepository : IVentaProductoAnulada
    {
        private readonly soport43_minegociocyjContext _contextcyj;       

        public VentaProductoAnuladaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }       

        public Task<bool> Delete(Tbventaproductoanulada entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tbventaproductoanulada>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Tbventaproductoanulada> GetById(Tbventaproductoanulada entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(List<Tbventaproductoanulada> entity)
        {
            for (int i = 0; i < entity.Count; i++)
            {
                await _contextcyj.Tbventaproductoanulada.AddAsync(entity[i]);
                //Agregar a inventario
                int cantidad = entity[i].Cantidad;
                //Tbproducto producto = await (from p in _contextcyj.Tbproducto
                //                             where p.IdProducto == entity[i].IdProducto
                //                             select p).FirstOrDefaultAsync();
                Tbproducto tbproducto = await _contextcyj.Tbproducto
                    .Where(x => x.IdProducto.Equals(entity[i].IdProducto))
                    .FirstOrDefaultAsync();
                tbproducto.Existencia = tbproducto.Existencia + cantidad;
                var suma = await _contextcyj.SaveChangesAsync();
            }
            int query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return true;

            }
            else
            {
                return false;
            }           
        }

        public Task<bool> Put(Tbventaproductoanulada entity)
        {
            throw new NotImplementedException();
        }
    }
}
