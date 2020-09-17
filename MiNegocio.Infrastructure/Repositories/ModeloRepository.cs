using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;      

        public ModeloRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }       

        public async Task<List<Tbmodelo>> Combo(int idMarca, int idTipoEquipo)
        {
            List<Tbmodelo> tbmodelos = new List<Tbmodelo>();
            tbmodelos = await _contextcyj.Tbmodelo.Where(x => x.Marca == idMarca && x.TipoEquipo == idTipoEquipo).ToListAsync();
            return tbmodelos;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbmodelo.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbmodelo.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _contextcyj.Tbmodelo.AnyAsync(x => x.IdModelo == id);
        }

        public async Task<IEnumerable<Tbmodelo>> Get()
        {
            var entities = await _contextcyj.Tbmodelo.ToListAsync();
            return entities;
        }

        public async Task<Tbmodelo> GetById(int id)
        {
            var entity = await _contextcyj.Tbmodelo.FindAsync(id);
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
            await _contextcyj.Tbmodelo.AddAsync(entity);
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

        public async Task<Tbmodelo> Put(int id, Tbmodelo entity)
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
