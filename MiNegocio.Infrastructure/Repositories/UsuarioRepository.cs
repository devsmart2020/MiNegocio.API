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

        public async Task<bool> Delete(Tbusuario entity)
        {
            var usuario = await _contextcyj.Tbusuario.FindAsync(entity.DocId);
            _contextcyj.Tbusuario.Remove(usuario);
            int query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Tbusuario> GetById(Tbusuario entity)
        {
            return await _contextcyj.Tbusuario
                .Where(x => x.DocId == entity.DocId && x.Estado == 1)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tbusuario>> Get()
        {
            return await _contextcyj.Tbusuario
                .Where(x => x.IdPerfilNavigation.Perfil.Equals("VENDEDOR") || x.IdPerfilNavigation.Perfil.Equals("ADMINISTRADOR") && x.Estado == 1)
                .Select(x => new Tbusuario
                {
                    DocId = x.DocId,
                    Nombres = x.Nombres,

                })
                .OrderBy(x => x.Nombres)
                .ToListAsync();
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

        public async Task<Tbusuario> Put(Tbusuario usuario)
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
                    .Where(x => x.User.Equals(usuario.User) && x.Pass.Equals(usuario.Pass) && x.Estado == 1)
                    .FirstOrDefaultAsync();
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Tbusuario>> GetTecnicos()
        {
            return await _contextcyj.Tbusuario
                .Where(x => x.IdPerfilNavigation.Perfil.Equals("TECNICO"))
                .Select(x => new Tbusuario()
                {
                    DocId = x.DocId,
                    Nombres = $"{x.Nombres} {x.Apellidos}"
                })
                .ToListAsync();
        }

        public async Task<Tbusuario> GetByIdUser(Tbusuario entity)
        {
            return await _contextcyj.Tbusuario
               .Where(x => x.User == entity.User)
               .FirstOrDefaultAsync();
        }
    }
}

