using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class EstadoOrdenRepository : IEstadoOrden
    {
        private readonly soport43_minegociocyjContext _context;

        public EstadoOrdenRepository(soport43_minegociocyjContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tbestadoorden>> GetEstados()
        {
            return await _context.Tbestadoorden.OrderBy(x => x.IdEstadoOrden).ToListAsync();
        }
    }
}
