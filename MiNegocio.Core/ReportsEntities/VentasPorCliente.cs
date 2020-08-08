using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasPorCliente
    {
        public int Venta { get; set; }
        public string IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Teléfono { get; set; }
        public string Dirección { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdOrden { get; set; }
        public string FormaPago { get; set; }
        public string Usuario { get; set; }
        public string Observaciones { get; set; }

    }
}
