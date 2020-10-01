using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class NegocioRepository : INegocioRepository
    {
        private readonly soport43_minegociocyjContext _context;

        public NegocioRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }
        public async Task<Tbnegocio> GetById()
        {
            return await _context.Tbnegocio.FirstOrDefaultAsync();
        }
    }
}
