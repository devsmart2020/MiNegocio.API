using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbestadoorden
    {
        public Tbestadoorden()
        {
            Tborden = new HashSet<Tborden>();
        }

        public int IdEstadoOrden { get; set; }
        public string EstadoOrden { get; set; }

        public virtual ICollection<Tborden> Tborden { get; set; }
    }
}
