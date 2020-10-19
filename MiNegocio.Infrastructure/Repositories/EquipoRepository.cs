using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

      

        public EquipoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

      
        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbequipo.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbequipo.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<EquiposxCliente>> EquipoCliente(string idCliente)
        {
            IEnumerable<EquiposxCliente> list = await _contextcyj.Tbequipo.Where(x => x.IdCliente == idCliente)
                .Select(x => new EquiposxCliente()
                {
                    IdEquipo = x.IdEquipo,
                    IdModelo = x.IdModelo,
                    NomModelo = x.IdModeloNavigation.Modelo,
                    Marca = x.IdModeloNavigation.MarcaNavigation.Marca,
                    TipoEquipo = x.IdModeloNavigation.TipoEquipoNavigation.TipoEquipo,
                    Serie = x.Serie,
                    Imei1 = x.Imei1,
                    Imei2 = x.Imei2,
                    Color = x.Color,
                    Fecha = x.Fecha,
                    IdCliente = x.IdCliente,
                    NomCliente = $"{x.IdClienteNavigation.Nombres} { x.IdClienteNavigation.Apellidos}",
                    Observacion = x.Observacion
                })
                .OrderByDescending(x => x.IdEquipo)
                .ToListAsync();   
            return list;
        }

        public async Task<bool> Exists(int id)
        {
            return await _contextcyj.Tbequipo.AnyAsync(x => x.IdModelo == id);

        }

        public async Task<IEnumerable<Tbequipo>> Get()
        {
            var entities = await _contextcyj.Tbequipo.ToListAsync();
            return entities;
        }

        public async Task<Tbequipo> GetById(int id)
        {
            var entity = await _contextcyj.Tbequipo.FindAsync(id);
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
            await _contextcyj.Tbequipo.AddAsync(entity);
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

        public async Task<Tbequipo> Put(int id, Tbequipo entity)
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
