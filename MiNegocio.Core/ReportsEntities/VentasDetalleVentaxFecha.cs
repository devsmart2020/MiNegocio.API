using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasDetalleVentaxFecha
    {
        public int Factura { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public string FormaPago { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public int VlrCompra { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }
        public int Total { get; set; }

        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
