using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Tbmodelo>> Get();
        Task<Tbmodelo> Post(Tbmodelo entity);
        Task<Tbmodelo> GetById(int id);
        Task<Tbmodelo> Put(int id, Tbmodelo entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<List<Tbmodelo>> Combo(int idMarca, int idTipoEquipo);
    }
}
