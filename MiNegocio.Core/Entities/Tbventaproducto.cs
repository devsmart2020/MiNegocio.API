namespace MiNegocio.Core.Entities
{
    public partial class Tbventaproducto
    {
        public int IdVenta { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int VlrProducto { get; set; }
        public int Descuento { get; set; }

        public virtual Tbproducto IdProductoNavigation { get; set; }
        public virtual Tbventa IdVentaNavigation { get; set; }
    }
}
