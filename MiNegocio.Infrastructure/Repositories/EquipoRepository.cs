using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly soport43_minegociovillegasContext _context;

        public EquipoRepository(soport43_minegociovillegasContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbequipo.FindAsync(id);
            if (entity != null)
            {
                _context.Tbequipo.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<object> EquipoCliente(string idCliente)
        {
            var query = await (from e in _context.Tbequipo
                        join c in _context.Tbcliente on e.IdCliente equals c.DocId
                        join m in _context.Tbmodelo on e.IdModelo equals m.IdModelo
                        select new
                        {                            
                            Cliente = c.Nombres + " " + c.Apellidos,                            
                            e.IdModeloNavigation.Modelo,
                            e.Fecha,
                            e.Observacion,
                            e.IdEquipo,
                            e.IdCliente,
                            e.IdModelo,
                            e.Serie,
                            e.Imei1,
                            e.Imei2,
                            e.Color,
                            e.IdModeloNavigation.TipoEquipoNavigation.TipoEquipo,                           
                        }).ToListAsync();
          
            return query;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tbequipo.AnyAsync(x => x.IdModelo == id);

        }

        public async Task<IEnumerable<Tbequipo>> Get()
        {
            var entities = await _context.Tbequipo.ToListAsync();
            return entities;
        }

        public async Task<Tbequipo> GetById(int id)
        {
            var entity = await _context.Tbequipo.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbequipo> Post(Tbequipo entity)
        {
            await _context.Tbequipo.AddAsync(entity);
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

        public async Task<Tbequipo> Put(int id, Tbequipo entity)
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
