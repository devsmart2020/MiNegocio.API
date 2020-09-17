using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbventa
    {
        public Tbventa()
        {
            Tbcredito = new HashSet<Tbcredito>();
            Tbventaproducto = new HashSet<Tbventaproducto>();
            Tbventaservicio = new HashSet<Tbventaservicio>();
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
        public virtual Tborden IdOrdenNavigation { get; set; }
        public virtual Tbusuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Tbcredito> Tbcredito { get; set; }
        public virtual ICollection<Tbventaproducto> Tbventaproducto { get; set; }
        public virtual ICollection<Tbventaservicio> Tbventaservicio { get; set; }
    }
}
