using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public PerfilRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<Tbperfil>> GetPerfils()
        {
            return await _context.Tbperfil.ToListAsync();
        }

        public async Task<Tbperfil> GetPerfil(Tbperfil entity)
        {
            return await _context.Tbperfil
                .Where(x => x.IdPerfil == entity.IdPerfil || x.Perfil == entity.Perfil)
                .FirstOrDefaultAsync();
        }
    }
}
