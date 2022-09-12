using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjetoPadraoNetCore.Repository;
using System;

namespace ProjetoPadraoNetCore.WebApi.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 20));

            services.AddDbContextPool<ProjetoPadraoNetCoreDBContext>(dbContextOptions => dbContextOptions
                    .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion)
                    .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                );
        }
    }
}
