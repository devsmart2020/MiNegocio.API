using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasLiquidacionxFecha
    {
        public int Factura { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string IdProducto { get; set; }

        public string Producto { get; set; }
        public string FormaPago { get; set; }
        public int CostoProducto { get; set; }
        public int TotalCosto { get; set; }
        public int VlrCompra { get; set; }
        public int VlrVenta { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }
        public int TotalGanancia { get; set; }      
        public int TotalVenta { get; set; }

        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
