using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbcredito
    {
        public int IdCredito { get; set; }
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int Cartera { get; set; }
        public int Abono { get; set; }
        public sbyte PazySalvo { get; set; }

        public virtual Tbventa IdVentaNavigation { get; set; }
    }
}
