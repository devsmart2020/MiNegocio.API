using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbcliente
    {
        public Tbcliente()
        {
            Tbequipo = new HashSet<Tbequipo>();
            Tborden = new HashSet<Tborden>();
            Tbventa = new HashSet<Tbventa>();
            Tbventaanulada = new HashSet<Tbventaanulada>();
        }

        public string DocId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelAlternativo { get; set; }
        public string Email { get; set; }
        public sbyte Estado { get; set; }
        public string CodRecuperacion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<Tbequipo> Tbequipo { get; set; }
        public virtual ICollection<Tborden> Tborden { get; set; }
        public virtual ICollection<Tbventa> Tbventa { get; set; }
        public virtual ICollection<Tbventaanulada> Tbventaanulada { get; set; }
    }
}
