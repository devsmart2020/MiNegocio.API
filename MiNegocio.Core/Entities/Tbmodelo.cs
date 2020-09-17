using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbmodelo
    {
        public Tbmodelo()
        {
            Tbequipo = new HashSet<Tbequipo>();
            Tbproducto = new HashSet<Tbproducto>();
        }

        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public int Marca { get; set; }
        public int TipoEquipo { get; set; }

        public virtual Tbmarca MarcaNavigation { get; set; }
        public virtual Tbtipoequipo TipoEquipoNavigation { get; set; }
        public virtual ICollection<Tbequipo> Tbequipo { get; set; }
        public virtual ICollection<Tbproducto> Tbproducto { get; set; }
    }
}
