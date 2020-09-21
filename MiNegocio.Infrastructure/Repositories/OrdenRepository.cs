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
                .Where(x => x.IdOrden == entity.IdOrden || x.IdCliente == x.IdCliente || x.FechaEntra.Date == entity.FechaEntra.Date)
                .ToListAsync();
        }
        public async Task<Tborden> GetById(Tborden entity)
        {
            return await _context.Tborden.Where(x => x.IdOrden == entity.IdOrden)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Post(Tborden entity)
        {
            await _context.Tborden.AddAsync(entity);
            int query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> Put(Tborden entity)
        {
            throw new NotImplementedException();
        }
    }
}
