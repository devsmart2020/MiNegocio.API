namespace MiNegocio.Core.Entities
{
    public partial class Tbusuarioorden
    {
        public string IdUsuario { get; set; }
        public int IdOrden { get; set; }

        public virtual Tborden IdOrdenNavigation { get; set; }
        public virtual Tbusuario IdUsuarioNavigation { get; set; }
    }
}
