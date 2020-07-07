using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbservicio
    {
        public Tbservicio()
        {
            Tbventaservicio = new HashSet<Tbventaservicio>();
        }

        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public int IdTipoServicio { get; set; }
        public int VlrServicio { get; set; }

        public virtual Tbtiposervicio IdTipoServicioNavigation { get; set; }
        public virtual ICollection<Tbventaservicio> Tbventaservicio { get; set; }
    }
}
