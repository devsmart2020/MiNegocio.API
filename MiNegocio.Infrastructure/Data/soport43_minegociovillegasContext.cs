using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;

namespace MiNegocio.Infrastructure.Data
{
    public partial class soport43_minegociovillegasContext : DbContext
    {
        public soport43_minegociovillegasContext()
        {
        }

        public soport43_minegociovillegasContext(DbContextOptions<soport43_minegociovillegasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbcliente> Tbcliente { get; set; }
        public virtual DbSet<Tbcompra> Tbcompra { get; set; }
        public virtual DbSet<Tbconcepto> Tbconcepto { get; set; }
        public virtual DbSet<Tbcredito> Tbcredito { get; set; }
        public virtual DbSet<Tbegreso> Tbegreso { get; set; }
        public virtual DbSet<Tbegresoconcepto> Tbegresoconcepto { get; set; }
        public virtual DbSet<Tbequipo> Tbequipo { get; set; }
        public virtual DbSet<Tbestadocompra> Tbestadocompra { get; set; }
        public virtual DbSet<Tbestadoorden> Tbestadoorden { get; set; }
        public virtual DbSet<Tbformapago> Tbformapago { get; set; }
        public virtual DbSet<Tbmarca> Tbmarca { get; set; }
        public virtual DbSet<Tbmodelo> Tbmodelo { get; set; }
        public virtual DbSet<Tbnegocio> Tbnegocio { get; set; }
        public virtual DbSet<Tborden> Tborden { get; set; }
        public virtual DbSet<Tbperfil> Tbperfil { get; set; }
        public virtual DbSet<Tbproducto> Tbproducto { get; set; }
        public virtual DbSet<Tbproductoserial> Tbproductoserial { get; set; }
        public virtual DbSet<Tbproveedor> Tbproveedor { get; set; }
        public virtual DbSet<Tbreportes> Tbreportes { get; set; }
        public virtual DbSet<Tbservicio> Tbservicio { get; set; }
        public virtual DbSet<Tbtarifa> Tbtarifa { get; set; }
        public virtual DbSet<Tbtipoequipo> Tbtipoequipo { get; set; }
        public virtual DbSet<Tbtipoproducto> Tbtipoproducto { get; set; }
        public virtual DbSet<Tbtiporeporte> Tbtiporeporte { get; set; }
        public virtual DbSet<Tbtiposervicio> Tbtiposervicio { get; set; }
        public virtual DbSet<Tbusuario> Tbusuario { get; set; }
        public virtual DbSet<Tbusuarioorden> Tbusuarioorden { get; set; }
        public virtual DbSet<Tbventa> Tbventa { get; set; }
        public virtual DbSet<Tbventaanulada> Tbventaanulada { get; set; }
        public virtual DbSet<Tbventaproducto> Tbventaproducto { get; set; }
        public virtual DbSet<Tbventaservicio> Tbventaservicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbcliente>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PRIMARY");

                entity.ToTable("tbcliente");

                entity.Property(e => e.DocId)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CodRecuperacion)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Estado).HasColumnType("tinyint(4)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TelAlternativo)
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbcompra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PRIMARY");

                entity.ToTable("tbcompra");

                entity.HasIndex(e => e.IdEstadoCompra)
                    .HasName("fk_TbCompra_TbEstadoCompra1_idx");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("fk_TbCompra_TbProveedor1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TbCompra_TbUsuario1_idx");

                entity.Property(e => e.IdCompra).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEstadoCompra).HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Nfactura)
                    .HasColumnName("NFactura")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.VlrCompra).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstadoCompraNavigation)
                    .WithMany(p => p.Tbcompra)
                    .HasForeignKey(d => d.IdEstadoCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbCompra_TbEstadoCompra1");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Tbcompra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbCompra_TbProveedor1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tbcompra)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbCompra_TbUsuario1");
            });

            modelBuilder.Entity<Tbconcepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto)
                    .HasName("PRIMARY");

                entity.ToTable("tbconcepto");

                entity.Property(e => e.IdConcepto).HasColumnType("int(11)");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbcredito>(entity =>
            {
                entity.HasKey(e => e.IdCredito)
                    .HasName("PRIMARY");

                entity.ToTable("tbcredito");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("fk_TbCredito_TbVenta1_idx");

                entity.Property(e => e.IdCredito).HasColumnType("int(11)");

                entity.Property(e => e.Abono).HasColumnType("int(11)");

                entity.Property(e => e.Cartera).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.Property(e => e.PazySalvo).HasColumnType("tinyint(4)");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Tbcredito)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbCredito_TbVenta1");
            });

            modelBuilder.Entity<Tbegreso>(entity =>
            {
                entity.HasKey(e => e.IdEgreso)
                    .HasName("PRIMARY");

                entity.ToTable("tbegreso");

                entity.Property(e => e.IdEgreso).HasColumnType("int(11)");

                entity.Property(e => e.CtaxPagar).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FormaPago).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbegresoconcepto>(entity =>
            {
                entity.HasKey(e => new { e.IdEgreso, e.IdConcepto })
                    .HasName("PRIMARY");

                entity.ToTable("tbegresoconcepto");

                entity.HasIndex(e => e.IdConcepto)
                    .HasName("fk_TbEgresoConcepto_TbConcepto1_idx");

                entity.Property(e => e.IdEgreso).HasColumnType("int(11)");

                entity.Property(e => e.IdConcepto).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.Descuento).HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.VlrUnitario).HasColumnType("int(11)");

                entity.HasOne(d => d.IdConceptoNavigation)
                    .WithMany(p => p.Tbegresoconcepto)
                    .HasForeignKey(d => d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbEgresoConcepto_TbConcepto1");

                entity.HasOne(d => d.IdEgresoNavigation)
                    .WithMany(p => p.Tbegresoconcepto)
                    .HasForeignKey(d => d.IdEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbEgresoConcepto_TbEgreso1");
            });

            modelBuilder.Entity<Tbequipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo)
                    .HasName("PRIMARY");

                entity.ToTable("tbequipo");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_TbEquipo_TbCliente1_idx");

                entity.HasIndex(e => e.IdModelo)
                    .HasName("fk_TbEquipo_TbModelo1_idx");

                entity.HasIndex(e => e.Imei1)
                    .HasName("Imei1_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Imei2)
                    .HasName("Imei2_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdEquipo).HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdModelo).HasColumnType("int(11)");

                entity.Property(e => e.Imei1)
                    .HasColumnType("varchar(17)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Imei2)
                    .HasColumnType("varchar(17)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Observacion)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Serie)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tbequipo)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbEquipo_TbCliente1");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Tbequipo)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbEquipo_TbModelo1");
            });

            modelBuilder.Entity<Tbestadocompra>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCompra)
                    .HasName("PRIMARY");

                entity.ToTable("tbestadocompra");

                entity.Property(e => e.IdEstadoCompra).HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbestadoorden>(entity =>
            {
                entity.HasKey(e => e.IdEstadoOrden)
                    .HasName("PRIMARY");

                entity.ToTable("tbestadoorden");

                entity.Property(e => e.IdEstadoOrden).HasColumnType("int(11)");

                entity.Property(e => e.EstadoOrden)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbformapago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("PRIMARY");

                entity.ToTable("tbformapago");

                entity.Property(e => e.IdFormaPago).HasColumnType("int(11)");

                entity.Property(e => e.FormaPago)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbmarca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PRIMARY");

                entity.ToTable("tbmarca");

                entity.Property(e => e.IdMarca).HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbmodelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PRIMARY");

                entity.ToTable("tbmodelo");

                entity.HasIndex(e => e.Marca)
                    .HasName("fk_TbModelo_TbMarca1_idx");

                entity.HasIndex(e => e.TipoEquipo)
                    .HasName("fk_TbModelo_TbTipoEquipo1_idx");

                entity.Property(e => e.IdModelo).HasColumnType("int(11)");

                entity.Property(e => e.Marca).HasColumnType("int(11)");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TipoEquipo).HasColumnType("int(11)");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Tbmodelo)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbModelo_TbMarca1");

                entity.HasOne(d => d.TipoEquipoNavigation)
                    .WithMany(p => p.Tbmodelo)
                    .HasForeignKey(d => d.TipoEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbModelo_TbTipoEquipo1");
            });

            modelBuilder.Entity<Tbnegocio>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PRIMARY");

                entity.ToTable("tbnegocio");

                entity.HasIndex(e => e.Nit)
                    .HasName("Nit_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Nit)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CodRecuperacion)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CtaBancoTitular)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Estado).HasColumnType("tinyint(4)");

                entity.Property(e => e.Hwid)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdTitular)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Imagen)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.PermisoTic)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Regimen)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Serial)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TelTitular)
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TelefonoAlterno)
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TipoCuentaTitular)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.TitularNombre)
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tborden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PRIMARY");

                entity.ToTable("tborden");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_TbOrden_TbCliente1_idx");

                entity.HasIndex(e => e.IdEquipo)
                    .HasName("fk_TbOrden_TbEquipo1_idx");

                entity.HasIndex(e => e.IdEstadoOrden)
                    .HasName("fk_TbOrden_TbEstadoOrden1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TbOrden_TbUsuario1_idx");

                entity.Property(e => e.IdOrden).HasColumnType("int(11)");

                entity.Property(e => e.DatosBloqueo)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DiagnosticoCliente)
                    .IsRequired()
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.DiagnosticoTecnico)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.FechaEntra).HasColumnType("datetime");

                entity.Property(e => e.FechaRevision).HasColumnType("datetime");

                entity.Property(e => e.FechaSale).HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnType("varchar(260)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdEquipo).HasColumnType("int(11)");

                entity.Property(e => e.IdEstadoOrden).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MicroSd)
                    .HasColumnName("MicroSD")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Presupuesto).HasColumnType("int(11)");

                entity.Property(e => e.Sim)
                    .HasColumnName("SIM")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ubicacion)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tborden)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbOrden_TbCliente1");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Tborden)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbOrden_TbEquipo1");

                entity.HasOne(d => d.IdEstadoOrdenNavigation)
                    .WithMany(p => p.Tborden)
                    .HasForeignKey(d => d.IdEstadoOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbOrden_TbEstadoOrden1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tborden)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbOrden_TbUsuario1");
            });

            modelBuilder.Entity<Tbperfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("tbperfil");

                entity.Property(e => e.IdPerfil).HasColumnType("int(11)");

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbproducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tbproducto");

                entity.HasIndex(e => e.IdModelo)
                    .HasName("fk_TbProducto_TbModelo1_idx");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("fk_TbProducto_TbProveedor1_idx");

                entity.HasIndex(e => e.IdTipoProducto)
                    .HasName("fk_TbProducto_TbTipoProducto1_idx");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Costo).HasColumnType("int(11)");

                entity.Property(e => e.Existencia).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdModelo).HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdTipoProducto).HasColumnType("int(11)");

                entity.Property(e => e.Producto)
                    .IsRequired()
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.StockMaximo).HasColumnType("int(11)");

                entity.Property(e => e.StockMinimo).HasColumnType("int(11)");

                entity.Property(e => e.VlrVenta).HasColumnType("int(11)");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Tbproducto)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_TbProducto_TbModelo1");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Tbproducto)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbProducto_TbProveedor1");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Tbproducto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbProducto_TbTipoProducto1");
            });

            modelBuilder.Entity<Tbproductoserial>(entity =>
            {
                entity.HasKey(e => e.Serie1)
                    .HasName("PRIMARY");

                entity.ToTable("tbproductoserial");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("fk_TbLote_TbProducto1_idx");

                entity.HasIndex(e => e.Serie2)
                    .HasName("Serie2_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Serie1)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdProducto)
                    .IsRequired()
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Serial)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Serie2)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Tbproductoserial)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbLote_TbProducto1");
            });

            modelBuilder.Entity<Tbproveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("tbproveedor");

                entity.Property(e => e.IdProveedor)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Estado).HasColumnType("tinyint(4)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Proveedor)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbreportes>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("PRIMARY");

                entity.ToTable("tbreportes");

                entity.HasIndex(e => e.IdTipoReporte)
                    .HasName("fk_TbReportes_TbTipoReporte1_idx");

                entity.Property(e => e.IdReporte).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoReporte).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdTipoReporteNavigation)
                    .WithMany(p => p.Tbreportes)
                    .HasForeignKey(d => d.IdTipoReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbReportes_TbTipoReporte1");
            });

            modelBuilder.Entity<Tbservicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PRIMARY");

                entity.ToTable("tbservicio");

                entity.HasIndex(e => e.IdTipoServicio)
                    .HasName("fk_TbServicio_TbTipoServicio1_idx");

                entity.Property(e => e.IdServicio).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoServicio).HasColumnType("int(11)");

                entity.Property(e => e.Servicio)
                    .IsRequired()
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.VlrServicio).HasColumnType("int(11)");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.Tbservicio)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbServicio_TbTipoServicio1");
            });

            modelBuilder.Entity<Tbtarifa>(entity =>
            {
                entity.HasKey(e => e.IdTarifa)
                    .HasName("PRIMARY");

                entity.ToTable("tbtarifa");

                entity.Property(e => e.IdTarifa).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Valor).HasColumnType("decimal(6,2)");
            });

            modelBuilder.Entity<Tbtipoequipo>(entity =>
            {
                entity.HasKey(e => e.IdTipoEquipo)
                    .HasName("PRIMARY");

                entity.ToTable("tbtipoequipo");

                entity.Property(e => e.IdTipoEquipo).HasColumnType("int(11)");

                entity.Property(e => e.TipoEquipo)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbtipoproducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tbtipoproducto");

                entity.Property(e => e.IdTipoProducto).HasColumnType("int(11)");

                entity.Property(e => e.TipoProducto)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbtiporeporte>(entity =>
            {
                entity.HasKey(e => e.IdTipoReporte)
                    .HasName("PRIMARY");

                entity.ToTable("tbtiporeporte");

                entity.Property(e => e.IdTipoReporte).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbtiposervicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio)
                    .HasName("PRIMARY");

                entity.ToTable("tbtiposervicio");

                entity.Property(e => e.IdTipoServicio).HasColumnType("int(11)");

                entity.Property(e => e.TipoServicio)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Tbusuario>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PRIMARY");

                entity.ToTable("tbusuario");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("fk_TbUsuario_TbPerfil_idx");

                entity.Property(e => e.DocId)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CodigoRecuperacion)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Estado).HasColumnType("tinyint(4)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdPerfil).HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Tbusuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbUsuario_TbPerfil");
            });

            modelBuilder.Entity<Tbusuarioorden>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdOrden })
                    .HasName("PRIMARY");

                entity.ToTable("tbusuarioorden");

                entity.HasIndex(e => e.IdOrden)
                    .HasName("fk_TbUsuarioOrden_TbOrden1_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdOrden).HasColumnType("int(11)");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.Tbusuarioorden)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbUsuarioOrden_TbOrden1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tbusuarioorden)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbUsuarioOrden_TbUsuario1");
            });

            modelBuilder.Entity<Tbventa>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PRIMARY");

                entity.ToTable("tbventa");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_TbVenta_TbCliente1_idx");

                entity.HasIndex(e => e.IdFormaPago)
                    .HasName("fk_TbVenta_TbFormaPago1_idx");

                entity.HasIndex(e => e.IdNegocio)
                    .HasName("fk_TbVenta_TbNegocio1_idx");

                entity.HasIndex(e => e.IdOrden)
                    .HasName("fk_TbVenta_TbOrden1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TbVenta_TbUsuario1_idx");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdFormaPago).HasColumnType("int(11)");

                entity.Property(e => e.IdNegocio)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdOrden).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tbventa)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVenta_TbCliente1");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Tbventa)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVenta_TbFormaPago1");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Tbventa)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVenta_TbNegocio1");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.Tbventa)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("fk_TbVenta_TbOrden1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tbventa)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVenta_TbUsuario1");
            });

            modelBuilder.Entity<Tbventaanulada>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("PRIMARY");

                entity.ToTable("tbventaanulada");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("IdVEnta_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Consecutivo).HasColumnType("int(11)");

                entity.Property(e => e.CantidadProducto).HasColumnType("int(11)");

                entity.Property(e => e.CantidadServicio).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.IdServicio).HasColumnType("int(11)");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithOne(p => p.Tbventaanulada)
                    .HasForeignKey<Tbventaanulada>(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVentaAnulada_TbVenta1");
            });

            modelBuilder.Entity<Tbventaproducto>(entity =>
            {
                entity.HasKey(e => new { e.IdVenta, e.IdProducto })
                    .HasName("PRIMARY");

                entity.ToTable("tbventaproducto");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("fk_TbVentaProducto_TbProducto1_idx");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.Descuento).HasColumnType("int(11)");

                entity.Property(e => e.VlrProducto).HasColumnType("int(11)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Tbventaproducto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVentaProducto_TbProducto1");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Tbventaproducto)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVentaProducto_TbVenta1");
            });

            modelBuilder.Entity<Tbventaservicio>(entity =>
            {
                entity.HasKey(e => new { e.IdVenta, e.IdServicio })
                    .HasName("PRIMARY");

                entity.ToTable("tbventaservicio");

                entity.HasIndex(e => e.IdServicio)
                    .HasName("fk_TbVentaServicio_TbServicio1_idx");

                entity.Property(e => e.IdVenta).HasColumnType("int(11)");

                entity.Property(e => e.IdServicio).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.Descuento).HasColumnType("int(11)");

                entity.Property(e => e.VlrServicio).HasColumnType("int(11)");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Tbventaservicio)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVentaServicio_TbServicio1");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Tbventaservicio)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbVentaServicio_TbVenta1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
