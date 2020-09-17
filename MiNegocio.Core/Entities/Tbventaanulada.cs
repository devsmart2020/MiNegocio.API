using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbventaanulada
    {
        public Tbventaanulada()
        {
            Tbventaproductoanulada = new HashSet<Tbventaproductoanulada>();
        }

        public int IdVenta { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdOrden { get; set; }
        public int IdFormaPago { get; set; }
        public string IdUsuario { get; set; }
        public string IdNegocio { get; set; }
        public string Observaciones { get; set; }

        public virtual Tbcliente IdClienteNavigation { get; set; }
        public virtual Tbformapago IdFormaPagoNavigation { get; set; }
        public virtual Tbnegocio IdNegocioNavigation { get; set; }
        public virtual Tbusuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Tbventaproductoanulada> Tbventaproductoanulada { get; set; }
    }
}
