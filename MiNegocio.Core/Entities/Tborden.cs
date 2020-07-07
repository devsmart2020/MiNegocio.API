using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tborden
    {
        public Tborden()
        {
            Tbusuarioorden = new HashSet<Tbusuarioorden>();
            Tbventa = new HashSet<Tbventa>();
        }

        public int IdOrden { get; set; }
        public DateTime FechaEntra { get; set; }
        public DateTime FechaRevision { get; set; }
        public DateTime FechaSale { get; set; }
        public string IdCliente { get; set; }
        public int IdEquipo { get; set; }
        public int IdEstadoOrden { get; set; }
        public sbyte? MicroSd { get; set; }
        public sbyte? Sim { get; set; }
        public string DatosBloqueo { get; set; }
        public string Foto { get; set; }
        public string DiagnosticoCliente { get; set; }
        public string DiagnosticoTecnico { get; set; }
        public int? Presupuesto { get; set; }
        public string Ubicacion { get; set; }
        public string IdUsuario { get; set; }

        public virtual Tbcliente IdClienteNavigation { get; set; }
        public virtual Tbequipo IdEquipoNavigation { get; set; }
        public virtual Tbestadoorden IdEstadoOrdenNavigation { get; set; }
        public virtual Tbusuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Tbusuarioorden> Tbusuarioorden { get; set; }
        public virtual ICollection<Tbventa> Tbventa { get; set; }
    }
}
