

namespace MiNegocio.Core.Entities
{
    public partial class Tbventaproductoanulada
    {
        public int IdVenta { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int VlrProducto { get; set; }
        public int Descuento { get; set; }
        public string Serial1 { get; set; }
        public string Serial2 { get; set; }

        public virtual Tbproducto IdProductoNavigation { get; set; }
        public virtual Tbventaanulada IdVentaNavigation { get; set; }
    }
}
