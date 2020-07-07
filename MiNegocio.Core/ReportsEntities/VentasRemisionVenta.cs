using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class VentasRemisionVenta
    {
        public int IdVenta { get; set; }
        public string IdCliente { get; set; }
        public string NomCliente { get; set; }
        public string TelCliente { get; set; }
        public string DireccionCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdOrden { get; set; }
        public string FormaPago { get; set; }
        public string Usuario { get; set; }
        public string Observaciones { get; set; }
        //Negocio
        public string Nit { get; set; }
        public string NombreNegocio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoAlterno { get; set; }
        public string TitularNombre { get; set; }
        public string IdTitular { get; set; }
        public string TelTitular { get; set; }
        public string CtaBancoTitular { get; set; }
        public string TipoCuentaTitular { get; set; }
        public string Regimen { get; set; }
        public string PermisoTic { get; set; }
        public string Imagen { get; set; }
    }
}
