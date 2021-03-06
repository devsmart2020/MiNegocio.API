﻿using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class OrdenRemisionLocal
    {
        public int IdOrden { get; set; }
        public DateTime FechaEntra { get; set; }
        public DateTime FechaRevision { get; set; }
        public DateTime FechaSale { get; set; }
        public string IdCliente { get; set; }
        public string NomCliente { get; set; }
        public int IdEquipo { get; set; }
        public string Marca { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int IdEstadoOrden { get; set; }
        public string Estado { get; set; }
        public sbyte? MicroSd { get; set; }
        public sbyte? Sim { get; set; }
        public string DatosBloqueo { get; set; }
        public string DiagnosticoCliente { get; set; }
        public string DiagnosticoTecnico { get; set; }
        public int? Presupuesto { get; set; }
        public string Ubicacion { get; set; }
        public string IdTecnico { get; set; }
        public string Tecnico { get; set; }
    }
}
