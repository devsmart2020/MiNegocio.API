using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class EquiposxCliente
    {
        public int IdEquipo { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public string NomCliente { get; set; }
        public int IdModelo { get; set; }
        public string NomModelo { get; set; }
        public string Marca { get; set; }
        public string TipoEquipo { get; set; }
        public string Serie { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Color { get; set; }
        public string Observacion { get; set; }
    }
}
