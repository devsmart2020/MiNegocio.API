using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbusuario
    {
        public Tbusuario()
        {
            Tbcompra = new HashSet<Tbcompra>();
            Tborden = new HashSet<Tborden>();
            Tbusuarioorden = new HashSet<Tbusuarioorden>();
            Tbventa = new HashSet<Tbventa>();
        }

        public string DocId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int IdPerfil { get; set; }
        public sbyte Estado { get; set; }
        public string CodigoRecuperacion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Tbperfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Tbcompra> Tbcompra { get; set; }
        public virtual ICollection<Tborden> Tborden { get; set; }
        public virtual ICollection<Tbusuarioorden> Tbusuarioorden { get; set; }
        public virtual ICollection<Tbventa> Tbventa { get; set; }
    }
}
