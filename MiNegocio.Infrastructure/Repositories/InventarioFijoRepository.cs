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
    public class InventarioFijoRepository : IInventarioFijoRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public InventarioFijoRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(Tbinventariofijo entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tbinventariofijo> Get(Tbinventariofijo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tbinventariofijo>> GetAll(Tbinventariofijo entity)
        {
            return await _context.Tbinventariofijo.OrderBy(x => x.Fecha).ToListAsync();   
        }

        public async Task<bool> Post(Tbinventariofijo entity)
        {
            await _context.Tbinventariofijo.AddAsync(entity);
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

        public Task<bool> Put(Tbinventariofijo entity)
        {
            throw new NotImplementedException();
        }
    }
}
