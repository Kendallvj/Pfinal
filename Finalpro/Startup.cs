using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Finalpro.Models; // Asegúrate de tener el namespace correcto para tus modelos

namespace Finalpro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se usa para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuraciones de servicios aquí
        }

        // Este método se usa para configurar el pipeline de solicitud HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuraciones de middleware y manejo de errores aquí
        }
    }
}
