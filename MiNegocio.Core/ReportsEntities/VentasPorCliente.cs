using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasPorCliente
    {
        public int IdVenta { get; set; }
        public string IdCliente { get; set; }
        public string DocIdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TelCliente { get; set; }
        public string DireccionCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdOrden { get; set; }
        public string FormaPago { get; set; }
        public string Usuario { get; set; }
        public string Observaciones { get; set; }
       
       

    }
}
