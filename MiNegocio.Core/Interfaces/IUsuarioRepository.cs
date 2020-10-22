using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Tbusuario>> Get();
        Task<Tbusuario> Post(Tbusuario usuario);
        Task<Tbusuario> GetById(Tbusuario entity);
        Task<Tbusuario> GetByIdUser(Tbusuario entity);
        Task<Tbusuario> Put(Tbusuario usuario);
        Task<bool> Delete(Tbusuario entity);
        Task<bool> Exists(string idUsuario);
        Task<Tbusuario> Login(Tbusuario usuario);
        Task<IEnumerable<Tbusuario>> GetTecnicos();


    }
}
