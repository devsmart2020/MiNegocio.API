using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class ComprasxFecha
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Nfactura { get; set; }
        public string EstadoCompra { get; set; }
        public int VlrCompra { get; set; }
        public string Observaciones { get; set; }
        public string Usuario { get; set; }
        public int TotalCompra { get; set; }

        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
