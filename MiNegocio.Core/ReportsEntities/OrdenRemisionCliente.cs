using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class OrdenRemisionCliente
    {
        public int IdOrden { get; set; }
        public DateTime FechaEntra { get; set; }       
        public string IdCliente { get; set; }
        public string NomCliente { get; set; }
        public int IdEquipo { get; set; }
        public string NomEquipo { get; set; }
        public string Marca { get; set; }
        public string TipoEquipo { get; set; }        
        public sbyte? MicroSd { get; set; }
        public sbyte? Sim { get; set; }        
        public string DiagnosticoCliente { get; set; }
        public string DiagnosticoTecnico { get; set; }
        public string Ubicacion { get; set; }
        public string IdUsuario { get; set; }
        public string NomUsuario { get; set; }

        //Negocio      
        public string NitNegocio { get; set; }
        public string NombreNegocio { get; set; }
        public string DireccionNegocio { get; set; }
        public string TelefonoNegocio { get; set; }
        public string TelefonoAlternoNegocio { get; set; }       
        public string PermisoTic { get; set; }
        public string Responsabilidad { get; set; }
        public string Garantia { get; set; }
    }
}
