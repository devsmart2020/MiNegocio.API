using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using MiNegocio.Infrastructure.Repositories;

namespace MiNegocio.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<soport43_minegociocyjContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ConnectionMySqlCyj")));
            services.AddControllers();

            //Resolver Dependencias
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<ITipoEquipoRepository, TipoEquipoRepository>();
            services.AddTransient<IModeloRepository, ModeloRepository>();
            services.AddTransient<IEquipoRepository, EquipoRepository>();
            services.AddTransient<ICompraRepository, CompraRepository>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<IEstadoCompraRepository, EstadoCompraRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<ITipoProductoRepository, TipoProductoRepository>();
            services.AddTransient<IFormaPagoRepository, FormaPagoRepository>();
            services.AddTransient<IVentaRepository, VentaRepository>();
            services.AddTransient<IVentaProductoRepository, VentaProductoRepository>();
            services.AddTransient<IProductoSerialRepository, ProductoSerialRepository>();
            services.AddTransient<IReporteRepository, ReporteRepository>();
            services.AddTransient<ITipoReporteRepository, TipoReporteRepository>();
            services.AddTransient<ICreditoRepository, CreditoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
