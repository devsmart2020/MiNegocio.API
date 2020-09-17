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
    public class CompraRepository : ICompraRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

       

        public CompraRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
        

        public Task<object> CompraProveedor(string idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<object> CompraxUsuario(string idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbcompra.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbcompra.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<ComprasxFecha>> ComprasxFecha(DateTime fchaIni, DateTime fchaFin)
        {
            IEnumerable<ComprasxFecha> comprasxFechas = await _contextcyj.Tbcompra
                .Select(x => new ComprasxFecha()
                {
                    Nfactura = x.Nfactura,
                    Fecha = x.Fecha,
                    Proveedor = x.IdProveedorNavigation.Proveedor,
                    EstadoCompra = x.IdEstadoCompraNavigation.Estado,
                    Observaciones = x.Observaciones,
                    Usuario = x.IdUsuarioNavigation.Nombres,
                    VlrCompra = x.VlrCompra,
                    FechaIni = fchaIni,
                    FechaFin = fchaFin
                })
                .ToListAsync();

            return comprasxFechas;
        }

        public async Task<bool> Exists(int id)
        {
            return await _contextcyj.Tbcompra.AnyAsync(x => x.IdCompra == id);

        }

        public async Task<IEnumerable<Tbcompra>> Get()
        {
            var entities = await _contextcyj.Tbcompra.ToListAsync();
            return entities;
        }

        public async Task<Tbcompra> GetById(int id)
        {
            var entity = await _contextcyj.Tbcompra.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbcompra> Post(Tbcompra entity)
        {
            await _contextcyj.Tbcompra.AddAsync(entity);
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

        public async Task<Tbcompra> Put(int id, Tbcompra entity)
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
