using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NascorpLib.Cache.Redis;
using Newtonsoft.Json;
using ProjetoPadraoNetCore.ApplicationService;
using ProjetoPadraoNetCore.ApplicationService.AuthenticationService;
using ProjetoPadraoNetCore.ApplicationService.LoginService;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.IRepository;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Repository.Repositories;

namespace ProjetoPadraoNetCore.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<DbContext>(sp => sp.GetService<ProjetoPadraoNetCoreDBContext>());
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
            };

            services.AddSingleton<CacheExchange>(provider => new CacheExchange(Config.CacheRedisConnection, Config.CacheRedisDatabase, Config.CacheInstanceName, Config.CacheExpireTime, Config.CacheRedisTimeout, options));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IJwtTokenApplication, JwtTokenApplication>();
            services.AddTransient<ILoginApplication, LoginApplication>();

            services.AddTransient<IMeuServicoApplicationService, MeuServicoApplicationService>();
            services.AddTransient<IMeuServicoRepository, MeuServicoRepository>();
        }
    }
}
