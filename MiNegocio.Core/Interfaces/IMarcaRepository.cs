using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Tbmarca>> Get();
        Task<Tbmarca> Post(Tbmarca entity);
        Task<Tbmarca> GetById(int id);
        Task<Tbmarca> Put(int id, Tbmarca entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
    }
}
