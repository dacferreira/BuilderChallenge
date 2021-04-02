using Builders.Dominio.Interfaces;
using Builders.Infrastructure;
using Builders.Infrastructure.Repositorio;
using Builders.Ioc.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Builders.Ioc
{
    public static class ControladorDeDependenciasDoIoC
    {
        public static IServiceCollection RegistrarDependenciasDoIoC(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BuildersDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.InjetarClassesQueImplementam(typeof(IServico))
                   .InjetarClassesQueImplementam(typeof(IRepositorio))
                   .InjetarClassesQueImplementam(typeof(IServico))
                   ;

            return service;
        }

    }
}
