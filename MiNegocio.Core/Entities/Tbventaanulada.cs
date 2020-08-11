using System;

namespace MiNegocio.Core.Entities
{
    public partial class Tbventaanulada
    {
        public int Consecutivo { get; set; }
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Observaciones { get; set; }
        public int? IdServicio { get; set; }
        public string IdProducto { get; set; }
        public int? CantidadServicio { get; set; }
        public int? CantidadProducto { get; set; }
        public int TotalVenta { get; set; }

        public virtual Tbventa IdVentaNavigation { get; set; }
    }
}
