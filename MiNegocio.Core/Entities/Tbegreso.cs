using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbegreso
    {
        public Tbegreso()
        {
            Tbegresoconcepto = new HashSet<Tbegresoconcepto>();
        }

        public int IdEgreso { get; set; }
        public DateTime Fecha { get; set; }
        public int FormaPago { get; set; }
        public int CtaxPagar { get; set; }
        public string IdUsuario { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<Tbegresoconcepto> Tbegresoconcepto { get; set; }
    }
}
