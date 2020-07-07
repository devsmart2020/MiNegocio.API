using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasxFecha
    {
        public int IdVenta { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string FormaPago { get; set; }

        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
