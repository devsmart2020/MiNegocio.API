﻿using Microsoft.EntityFrameworkCore;
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
    public class OrdenRepository : IOrdenRepository<Tborden>
    {
        private readonly soport43_minegociocyjContext _context;

        public OrdenRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(Tborden entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tborden>> Get(Tborden entity)
        {
            return await _context.Tborden
                .Where(x => entity.IdOrden == x.IdOrden || entity.IdCliente == x.IdCliente || entity.FechaEntra.Date == x.FechaEntra.Date)
                .ToListAsync();
        }
        public async Task<Tborden> GetById(Tborden entity)
        {
            return await _context.Tborden.Where(x => x.IdOrden == entity.IdOrden)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrdenRemisionLocal>> OrdenLocal(OrdenRemisionLocal entity)
        {
            return await _context.Tborden
                .Where(x => x.IdOrden == entity.IdOrden || x.IdCliente == entity.IdCliente || x.FechaEntra.Date == entity.FechaEntra.Date)
                .Select(x => new OrdenRemisionLocal
                {
                    IdOrden = x.IdOrden,
                    FechaEntra = x.FechaEntra,
                    FechaRevision = x.FechaRevision,
                    FechaSale = x.FechaSale,
                    IdCliente = x.IdCliente,
                    NomCliente = $"{x.IdClienteNavigation.Nombres} {x.IdClienteNavigation.Apellidos}",
                    IdEquipo = x.IdEquipo,
                    Marca = x.IdEquipoNavigation.IdModeloNavigation.MarcaNavigation.Marca,
                    TipoEquipo = x.IdEquipoNavigation.IdModeloNavigation.TipoEquipoNavigation.TipoEquipo,
                    Modelo = x.IdEquipoNavigation.IdModeloNavigation.Modelo,
                    IdEstadoOrden = x.IdEstadoOrden,
                    Estado = x.IdEstadoOrdenNavigation.EstadoOrden,
                    MicroSd = x.MicroSd,
                    Sim = x.Sim,
                    DatosBloqueo = x.DatosBloqueo,
                    DiagnosticoCliente = x.DiagnosticoCliente,
                    DiagnosticoTecnico = x.DiagnosticoTecnico,
                    Presupuesto = x.Presupuesto,
                    Ubicacion = x.Ubicacion,
                    IdTecnico = x.IdUsuario,
                    Tecnico = x.IdUsuarioNavigation.Nombres
                }).ToListAsync();

        }

        public async Task<Tborden> Post(Tborden entity)
        {
            await _context.Tborden.AddAsync(entity);
            int query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Task<bool> Put(Tborden entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrdenRemisionCliente>> RemisionCliente(OrdenRemisionCliente entity)
        {
            Tbnegocio tbnegocio = await _context.Tbnegocio.FirstOrDefaultAsync();
            return await _context.Tborden
                .Where(x => x.IdOrden == entity.IdOrden)
                .Select(x => new OrdenRemisionCliente()
                {
                    IdOrden = entity.IdOrden,
                    FechaEntra = x.FechaEntra,
                    IdCliente = x.IdCliente,
                    TelCliente = x.IdClienteNavigation.Telefono,
                    NomCliente = $"{x.IdClienteNavigation.Nombres} {x.IdClienteNavigation.Apellidos}",
                    NomEquipo = x.IdEquipoNavigation.IdModeloNavigation.Modelo,
                    Marca = x.IdEquipoNavigation.IdModeloNavigation.MarcaNavigation.Marca,
                    TipoEquipo = x.IdEquipoNavigation.IdModeloNavigation.TipoEquipoNavigation.TipoEquipo,
                    MicroSd = x.MicroSd,
                    Sim = x.Sim,
                    DiagnosticoCliente = x.DiagnosticoCliente,
                    DiagnosticoTecnico = x.DiagnosticoTecnico,
                    NomUsuario = x.IdUsuarioNavigation.Nombres,
                    NombreNegocio = tbnegocio.Nombre,
                    NitNegocio = tbnegocio.Nit,
                    TelefonoNegocio = tbnegocio.Telefono,
                    DireccionNegocio = tbnegocio.Direccion,     
                    Garantia = tbnegocio.Garantia,
                    Responsabilidad = tbnegocio.Responsabilidad
                }).ToListAsync();
        }
    }
}
