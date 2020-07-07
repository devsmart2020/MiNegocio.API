using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly soport43_minegocioContext _context;

        public ModeloRepository(soport43_minegocioContext context)
        {
            _context = context;
        }

        public async Task<List<Tbmodelo>> Combo(int idMarca, int idTipoEquipo)
        {
            List<Tbmodelo> tbmodelos = new List<Tbmodelo>();
            tbmodelos = await _context.Tbmodelo.Where(x => x.Marca == idMarca && x.TipoEquipo == idTipoEquipo).ToListAsync();
            return tbmodelos;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Tbmodelo.FindAsync(id);
            if (entity != null)
            {
                _context.Tbmodelo.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Tbmodelo.AnyAsync(x => x.IdModelo == id);
        }

        public async Task<IEnumerable<Tbmodelo>> Get()
        {
            var entities = await _context.Tbmodelo.ToListAsync();
            return entities;
        }

        public async Task<Tbmodelo> GetById(int id)
        {
            var entity = await _context.Tbmodelo.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbmodelo> Post(Tbmodelo entity)
        {
            await _context.Tbmodelo.AddAsync(entity);
            var query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbmodelo> Put(int id, Tbmodelo entity)
        {
            var query = await _context.SaveChangesAsync();
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
