using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbtiporeporte
    {
        public Tbtiporeporte()
        {
            Tbreportes = new HashSet<Tbreportes>();
        }

        public int IdTipoReporte { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tbreportes> Tbreportes { get; set; }
    }
}
