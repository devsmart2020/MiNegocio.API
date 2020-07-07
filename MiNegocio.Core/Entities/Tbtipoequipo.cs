using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbtipoequipo
    {
        public Tbtipoequipo()
        {
            Tbmodelo = new HashSet<Tbmodelo>();
        }

        public int IdTipoEquipo { get; set; }
        public string TipoEquipo { get; set; }

        public virtual ICollection<Tbmodelo> Tbmodelo { get; set; }
    }
}
