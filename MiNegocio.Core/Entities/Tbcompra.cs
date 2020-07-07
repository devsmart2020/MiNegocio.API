using System;

namespace MiNegocio.Core.Entities
{
    public partial class Tbcompra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public string IdProveedor { get; set; }
        public string Nfactura { get; set; }
        public int IdEstadoCompra { get; set; }
        public int VlrCompra { get; set; }
        public string Observaciones { get; set; }
        public string IdUsuario { get; set; }

        public virtual Tbestadocompra IdEstadoCompraNavigation { get; set; }
        public virtual Tbproveedor IdProveedorNavigation { get; set; }
        public virtual Tbusuario IdUsuarioNavigation { get; set; }
    }
}
