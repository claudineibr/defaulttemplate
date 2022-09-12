using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        public static void RegisterServices(IServiceCollection services, IConfiguration conf)
        {
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
            };

            var cache = new CacheExchange(conf.GetSection("Redis:Connection").Value, int.Parse(conf.GetSection("Redis:Database").Value), conf.GetSection("Redis:InstanceName").Value, int.Parse(conf.GetSection("Redis:ExpireTime").Value), int.Parse(conf.GetSection("Redis:Timeout").Value), options);
            services.AddSingleton<CacheExchange>(provider => cache);

            services.AddSingleton<CacheExchange>(provider => new CacheExchange(Config.CacheRedisConnection, Config.CacheRedisDatabase, Config.CacheInstanceName, Config.CacheExpireTime, Config.CacheRedisTimeout, options));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IJwtTokenApplication, JwtTokenApplication>();
            services.AddTransient<ILoginApplication, LoginApplication>();

            services.AddTransient<IMeuServicoApplicationService, MeuServicoApplicationService>();
            services.AddTransient<IMeuServicoRepository, MeuServicoRepository>();
        }
    }
}
