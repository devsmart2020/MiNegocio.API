namespace MiNegocio.Core.ReportsEntities
{
    public class VentasDetalleRemisionVenta
    {
        public int IdVenta { get; set; }
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int VlrProducto { get; set; }
        public int Descuento { get; set; }
        public int Total { get; set; }
    }
}
