using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ProductoSerialRepository : IProductoSerialRepository
    {
        private readonly soport43_minegocioContext _context;

        public ProductoSerialRepository(soport43_minegocioContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(List<string> id)
        {
            bool retorno = false;
            foreach (var item in id)
            {
                var entity = await _context.Tbproductoserial
              .FindAsync(item);
                if (entity != null)
                {
                    _context.Tbproductoserial.Remove(entity);
                    var query = await _context.SaveChangesAsync();
                    if (query > 0)
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
                else
                {
                    retorno = false;
                }
            }

            //for (int i = 0; i < id.Count; i++)
            //{
              
                
            //    if (entity != null)
            //    {
            //        _context.Tbproductoserial.Remove(entity);
            //        var query = await _context.SaveChangesAsync();
            //        if (query > 0)
            //        {
            //            retorno =  true;
            //        }
            //        else
            //        {
            //            retorno = false;
            //        }
            //    }
            //    else
            //    {
            //        retorno =  false;                   
            //    }
            //}
            return retorno;
            
           
        }

        public async Task<bool> Exists(string id)
        {
            return await _context.Tbproductoserial.AnyAsync(x => x.Serie1 == id);
        }

        public async Task<IEnumerable<Tbproductoserial>> Get()
        {
            var entities = await _context.Tbproductoserial.ToListAsync();
            return entities;
        }

        public async Task<Tbproductoserial> GetById(string id)
        {
            var entity = await _context.Tbproductoserial
                .Where(x => x.Serie1 == id || x.Serie2 == id)
                .FirstOrDefaultAsync();
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Tbproductoserial>> GetListById(string id)
        {
            return await _context.Tbproductoserial
                .Where(x => x.IdProducto == id)
                .ToListAsync();
        }

        public async Task<Tbproductoserial> Post(Tbproductoserial entity)
        {
            await _context.Tbproductoserial.AddAsync(entity);
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

        public async Task<bool> PostList(List<Tbproductoserial> entitiesList)
        {
            if (entitiesList.Count > 0)
            {
                await _context.Tbproductoserial.AddRangeAsync(entitiesList);
               
                var query = await _context.SaveChangesAsync();       
         
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

        public async Task<Tbproductoserial> Put(string id, Tbproductoserial entity)
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
