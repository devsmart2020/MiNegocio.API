using System;
using System.Collections.Generic;

namespace MiNegocio.Core.Entities
{
    public partial class Tbproducto
    {
        public Tbproducto()
        {
            Tbproductoserial = new HashSet<Tbproductoserial>();
            Tbventaproducto = new HashSet<Tbventaproducto>();
        }

        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public int Costo { get; set; }
        public int VlrVenta { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int Existencia { get; set; }
        public int IdTipoProducto { get; set; }
        public int? IdModelo { get; set; }
        public string IdProveedor { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Tbmodelo IdModeloNavigation { get; set; }
        public virtual Tbproveedor IdProveedorNavigation { get; set; }
        public virtual Tbtipoproducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<Tbproductoserial> Tbproductoserial { get; set; }
        public virtual ICollection<Tbventaproducto> Tbventaproducto { get; set; }
    }
}
