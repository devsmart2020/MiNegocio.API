using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbtarifa
    {
        public int IdTarifa { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
    }
}
