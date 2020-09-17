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
        private readonly soport43_minegociocyjContext _contextcyj;
      

        public UsuarioRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }       

        public async Task<bool> Delete(string idUsuario)
        {
            var usuario = await _contextcyj.Tbusuario.FindAsync(idUsuario);
            if (usuario != null)
            {
                _contextcyj.Tbusuario.Remove(usuario);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Tbusuario> GetById(string idUsuario)
        {
            var usuario = await _contextcyj.Tbusuario.FindAsync(idUsuario);
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
            var usuarios = await _contextcyj.Tbusuario.ToListAsync();
            return usuarios;
        }

        public async Task<Tbusuario> Post(Tbusuario usuario)
        {
            await _contextcyj.Tbusuario.AddAsync(usuario);
            var query = await _contextcyj.SaveChangesAsync();
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
            _contextcyj.Entry(usuario).State = EntityState.Modified;
            var query = await _contextcyj.SaveChangesAsync();
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
            return await _contextcyj.Tbusuario.AnyAsync(x => x.DocId == idUsuario);
        }

        public async Task<Tbusuario> Login(Tbusuario usuario)
        {
            if (usuario != null)
            {
                Tbusuario model = await _contextcyj.Tbusuario
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
