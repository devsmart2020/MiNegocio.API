using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class InventarioListatoReporte
    {
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public int Costo { get; set; }
        public int VlrVenta { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int Existencia { get; set; }
        public string TipoProducto { get; set; }
        public string Modelo { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalCostoxProducto { get; set; }
    }
}
