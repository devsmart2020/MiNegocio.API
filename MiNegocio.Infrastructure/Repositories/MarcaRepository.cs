using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly soport43_minegociovillegasContext _context;

        public MarcaRepository(soport43_minegociovillegasContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var marca = await _context.Tbmarca.FindAsync(id);
            if (marca != null)
            {
                _context.Tbmarca.Remove(marca);
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
            return await _context.Tbmarca.AnyAsync(x => x.IdMarca == id);
        }

        public async Task<IEnumerable<Tbmarca>> Get()
        {
            var entities = await _context.Tbmarca.ToListAsync();
            return entities;
        }

        public async Task<Tbmarca> GetById(int id)
        {
            var entity = await _context.Tbmarca.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbmarca> Post(Tbmarca entity)
        {
            await _context.Tbmarca.AddAsync(entity);
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

        public async Task<Tbmarca> Put(int id, Tbmarca entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
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
