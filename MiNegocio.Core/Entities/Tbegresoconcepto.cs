using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbegresoconcepto
    {
        public int IdEgreso { get; set; }
        public int IdConcepto { get; set; }
        public int VlrUnitario { get; set; }
        public int Cantidad { get; set; }
        public int? Descuento { get; set; }
        public string Observaciones { get; set; }

        public virtual Tbconcepto IdConceptoNavigation { get; set; }
        public virtual Tbegreso IdEgresoNavigation { get; set; }
    }
}
