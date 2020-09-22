using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class UsuarioOrdenRepository : IUsuarioOrden
    {
        private readonly soport43_minegociocyjContext _context;

        public UsuarioOrdenRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(Tbusuarioorden entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tbusuarioorden>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Tbusuarioorden> GetById(Tbusuarioorden entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(Tbusuarioorden entity)
        {
            await _context.Tbusuarioorden.AddAsync(entity);
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

        public Task<bool> Put(Tbusuarioorden entity)
        {
            throw new NotImplementedException();
        }
    }
}
