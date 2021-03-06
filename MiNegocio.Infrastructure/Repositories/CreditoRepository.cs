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
    public class CreditoRepository : ICreditoRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

     

        public CreditoRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }
       

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tbcredito>> Get()
        {
            var entities = await _contextcyj.Tbcredito.ToListAsync();
            return entities;
        }

        public Task<Tbcredito> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CreditoClienteCartera>> GetCreditoClientes()
        {
            IEnumerable<CreditoClienteCartera> creditoClientes = await _contextcyj.Tbcredito
                .Select(x => new CreditoClienteCartera()
                {
                    IdVenta = x.IdVenta,
                    Fecha = x.IdVentaNavigation.Fecha,
                    Documento = x.IdVentaNavigation.IdCliente,
                    Cliente = $"{x.IdVentaNavigation.IdClienteNavigation.Nombres} {x.IdVentaNavigation.IdClienteNavigation.Apellidos}",
                    Cartera = x.Cartera,
                    Abono = x.Abono
                })
                .ToListAsync();
            return creditoClientes;
        }

        public async Task<Tbcredito> Post(Tbcredito entity)
        {
            await _contextcyj.Tbcredito.AddAsync(entity);
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

        public Task<Tbcredito> Put(int id, Tbcredito entity)
        {
            throw new NotImplementedException();
        }
    }
}
