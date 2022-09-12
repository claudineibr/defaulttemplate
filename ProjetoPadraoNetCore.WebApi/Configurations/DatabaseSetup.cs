using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProjetoPadraoNetCore.Repository;
using System;

namespace ProjetoPadraoNetCore.WebApi.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContextPool<ProjetoPadraoNetCoreDBContext>((IServiceProvider sp, DbContextOptionsBuilder builder) =>
            {
                var env = sp.GetRequiredService<IWebHostEnvironment>();
                builder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
                builder.EnableDetailedErrors(env.IsDevelopment());
                builder.EnableSensitiveDataLogging(env.IsDevelopment());
            });
        }
    }
}
