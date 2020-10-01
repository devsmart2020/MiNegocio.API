using MiNegocio.Core.Entities;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface INegocioRepository
    {
        Task<Tbnegocio> GetById();        

    }
}
