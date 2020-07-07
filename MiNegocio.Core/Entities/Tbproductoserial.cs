using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbproductoserial
    {
        public string IdProducto { get; set; }
        public string Serie1 { get; set; }
        public string Serie2 { get; set; }
        public string Serial { get; set; }

        public virtual Tbproducto IdProductoNavigation { get; set; }
    }
}
