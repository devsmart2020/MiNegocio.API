using MiNegocio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IEstadoOrden
    {
        Task<IEnumerable<Tbestadoorden>> GetEstados();
    }
}
