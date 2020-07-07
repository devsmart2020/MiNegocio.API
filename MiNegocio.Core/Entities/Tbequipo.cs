using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbequipo
    {
        public Tbequipo()
        {
            Tborden = new HashSet<Tborden>();
        }

        public int IdEquipo { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public int IdModelo { get; set; }
        public string Serie { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Color { get; set; }
        public string Observacion { get; set; }

        public virtual Tbcliente IdClienteNavigation { get; set; }
        public virtual Tbmodelo IdModeloNavigation { get; set; }
        public virtual ICollection<Tborden> Tborden { get; set; }
    }
}
