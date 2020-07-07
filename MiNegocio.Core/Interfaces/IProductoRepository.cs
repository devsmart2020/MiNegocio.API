using MiNegocio.Core.Entities;
using MiNegocio.Core.ReportsEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Tbproducto>> Get();
        Task<Tbproducto> Post(Tbproducto entity);
        Task<bool> PostList(List<Tbproducto> entitiesList);
        Task<Tbproducto> GetById(string id);
        Task<Tbproducto> Put(string id, Tbproducto entity);
        Task<bool> Delete(string id);
        Task<bool> Exists(string id);       
        Task<IEnumerable<InventarioListatoReporte>> GetInventarioListado();

    }
}
