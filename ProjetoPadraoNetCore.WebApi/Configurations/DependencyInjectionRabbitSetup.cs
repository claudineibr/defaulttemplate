using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nascorp.Library.MQ.Rabbit;
using ProjetoPadraoNetCore.CrossCutting.IoC;
using System;

namespace ProjetoPadraoNetCore.WebApi.Configurations
{
    public static class DependencyInjectionRabbitSetup
    {
        public static void AddDependencyInjectionRabbitSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorRabbitBootStrapper.RegisterServices(services, configuration);
            NativeInjectorRabbitBootStrapper.RegisterBusServices(services, configuration);
        }

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            NativeInjectorRabbitBootStrapper.ConfigureBusServices(app);
        }
    }
}
