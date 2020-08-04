using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbnegocio
    {
        public Tbnegocio()
        {
            Tbventa = new HashSet<Tbventa>();
        }

        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlterno { get; set; }
        public string TitularNombre { get; set; }
        public string IdTitular { get; set; }
        public string TelTitular { get; set; }
        public string CtaBancoTitular { get; set; }
        public string TipoCuentaTitular { get; set; }
        public string Regimen { get; set; }
        public string PermisoTic { get; set; }
        public string Imagen { get; set; }
        public string Hwid { get; set; }
        public string Serial { get; set; }
        public string CodRecuperacion { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Tbventa> Tbventa { get; set; }
    }
}
