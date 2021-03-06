﻿using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ProductoSerialRepository : IProductoSerialRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

      

        public ProductoSerialRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
       

        public async Task<bool> Delete(List<string> id)
        {
            bool retorno = false;
            foreach (var item in id)
            {
                var entity = await _contextcyj.Tbproductoserial
              .FindAsync(item);
                if (entity != null)
                {
                    _contextcyj.Tbproductoserial.Remove(entity);
                    var query = await _contextcyj.SaveChangesAsync();
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
            //        _contextcyj.Tbproductoserial.Remove(entity);
            //        var query = await _contextcyj.SaveChangesAsync();
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
            return await _contextcyj.Tbproductoserial.AnyAsync(x => x.Serie1 == id);
        }

        public async Task<IEnumerable<Tbproductoserial>> Get()
        {
            var entities = await _contextcyj.Tbproductoserial.ToListAsync();
            return entities;
        }

        public async Task<Tbproductoserial> GetById(string id)
        {
            var entity = await _contextcyj.Tbproductoserial
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
            return await _contextcyj.Tbproductoserial
                .Where(x => x.IdProducto == id)
                .ToListAsync();
        }

        public async Task<Tbproductoserial> Post(Tbproductoserial entity)
        {
            await _contextcyj.Tbproductoserial.AddAsync(entity);
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

        public async Task<bool> PostList(List<Tbproductoserial> entitiesList)
        {
            if (entitiesList.Count > 0)
            {
                await _contextcyj.Tbproductoserial.AddRangeAsync(entitiesList);
               
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
            else
            {
                return false;
            }
        }

        public async Task<Tbproductoserial> Put(string id, Tbproductoserial entity)
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
