using System;

namespace MiNegocio.Core.Entities
{
    public partial class Tbinventariofijo
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Serial { get; set; }
        public int Costo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
    }
}
