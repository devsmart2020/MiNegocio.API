using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbperfil
    {
        public Tbperfil()
        {
            Tbusuario = new HashSet<Tbusuario>();
        }

        public int IdPerfil { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<Tbusuario> Tbusuario { get; set; }
    }
}
