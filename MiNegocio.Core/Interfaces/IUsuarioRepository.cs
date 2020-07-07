using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Tbusuario>> Get();
        Task<Tbusuario> Post(Tbusuario usuario);
        Task<Tbusuario> GetById(string idUsuario);
        Task<Tbusuario> Put(string idUsuario, Tbusuario usuario);
        Task<bool> Delete(string idUsuario);
        Task<bool> Exists(string idUsuario);
        Task<Tbusuario> Login(Tbusuario usuario);


    }
}
