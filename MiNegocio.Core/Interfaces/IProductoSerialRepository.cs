using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IProductoSerialRepository
    {
        Task<IEnumerable<Tbproductoserial>> Get();
        Task<IEnumerable<Tbproductoserial>> GetListById(string id);
        Task<Tbproductoserial> Post(Tbproductoserial entity);
        Task<bool> PostList(List<Tbproductoserial> entitiesList);
        Task<Tbproductoserial> GetById(string id);
        Task<Tbproductoserial> Put(string id, Tbproductoserial entity);
        Task<bool> Delete(List<string> id);
        Task<bool> Exists(string id);
    }
}
