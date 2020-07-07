using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbproveedor
    {
        public Tbproveedor()
        {
            Tbcompra = new HashSet<Tbcompra>();
            Tbproducto = new HashSet<Tbproducto>();
        }

        public string IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public sbyte Estado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<Tbcompra> Tbcompra { get; set; }
        public virtual ICollection<Tbproducto> Tbproducto { get; set; }
    }
}
