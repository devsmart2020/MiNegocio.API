using MiNegocio.Core.Entities;
using MiNegocio.Core.ReportsEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface ICreditoRepository
    {
        Task<IEnumerable<Tbcredito>> Get();
        Task<Tbcredito> Post(Tbcredito entity);
        Task<Tbcredito> GetById(int id);
        Task<Tbcredito> Put(int id, Tbcredito entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<CreditoClienteCartera>> GetCreditoClientes();
    }
}
