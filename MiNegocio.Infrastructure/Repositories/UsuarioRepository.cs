using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly soport43_minegociovillegasContext _context;

        public UsuarioRepository(soport43_minegociovillegasContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string idUsuario)
        {
            var usuario = await _context.Tbusuario.FindAsync(idUsuario);
            if (usuario != null)
            {
                _context.Tbusuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Tbusuario> GetById(string idUsuario)
        {
            var usuario = await _context.Tbusuario.FindAsync(idUsuario);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Tbusuario>> Get()
        {
            var usuarios = await _context.Tbusuario.ToListAsync();
            return usuarios;
        }

        public async Task<Tbusuario> Post(Tbusuario usuario)
        {
            await _context.Tbusuario.AddAsync(usuario);
            var query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbusuario> Put(string idUsuario, Tbusuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            var query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Exists(string idUsuario)
        {
            return await _context.Tbusuario.AnyAsync(x => x.DocId == idUsuario);
        }

        public async Task<Tbusuario> Login(Tbusuario usuario)
        {
            if (usuario != null)
            {
                Tbusuario model = await _context.Tbusuario
                    .Where(x => x.User.Equals(usuario.User) && x.Pass.Equals(usuario.Pass))
                    .FirstOrDefaultAsync();
                return model;
            }
            else
            {
                return null;
            }            
        }
    }
}
