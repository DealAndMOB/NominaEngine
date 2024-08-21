using Microsoft.EntityFrameworkCore;
using Nomina.Models;
using Nomina.Services.Implementacion;
using Nomina.Services.Interfaces;

namespace Nomina.InversionOfControl
{
    public static class InyeccionDependencias
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Context"));
            }
            );
            services.AddScoped<IEmpleoService, EmpleoService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IBonificacionDeGastoService, BonificacionDeGastoService>();
        }
    }
}
