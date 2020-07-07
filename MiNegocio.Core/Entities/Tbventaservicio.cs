namespace MiNegocio.Core.Entities
{
    public partial class Tbventaservicio
    {
        public int IdVenta { get; set; }
        public int IdServicio { get; set; }
        public int VlrServicio { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }

        public virtual Tbservicio IdServicioNavigation { get; set; }
        public virtual Tbventa IdVentaNavigation { get; set; }
    }
}
