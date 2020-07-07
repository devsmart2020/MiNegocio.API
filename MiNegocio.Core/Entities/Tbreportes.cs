using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbreportes
    {
        public int IdReporte { get; set; }
        public string Nombre { get; set; }
        public int IdTipoReporte { get; set; }

        public virtual Tbtiporeporte IdTipoReporteNavigation { get; set; }
    }
}
