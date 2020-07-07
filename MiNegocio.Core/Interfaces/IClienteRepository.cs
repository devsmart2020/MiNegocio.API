using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Tbcliente>> Get();
        Task<Tbcliente> Post(Tbcliente entity);
        Task<Tbcliente> GetById(string id);
        Task<Tbcliente> Put(string id, Tbcliente entity);
        Task<bool> Delete(string id);
        Task<bool> Exists(string id);
    }
}
