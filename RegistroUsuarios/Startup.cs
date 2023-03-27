using MediatR;
using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Aplicacion;
using RegistroUsuarios.Persistencia;

namespace RegistroUsuarios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ContextoUsuarios>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
            });

            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.Manejador));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}