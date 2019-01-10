using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProjetoPadraoNetCore.ApplicationService;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.IRepository;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Repository;
using ProjetoPadraoNetCore.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace ProjetoPadraoNetCore.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "ProjetoPadraoNetCore - Catalog HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API.",
                    TermsOfService = "Terms Of Service",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Claudinei Nascimento",
                        Email = "claudinei@nascorp.com.br"
                    },
                    License = new Swashbuckle.AspNetCore.Swagger.License
                    {
                        Name = "Apache 2.0",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    }
                });
            });

            //services.AddDbContext<ProjetoPadraoNetCoreDBContext>(option => option.UseOracle(Config.ConnectionString));
            services.AddDbContext<ProjetoPadraoNetCoreDBContext>(option => option.UseMySql(Config.ConnectionString, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
            }));

            services.AddResponseCaching();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = new List<string> { "application/json" };
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Config.CacheServer;
            //    options.InstanceName = Config.CacheInstanceName;
            //});
            services.AddScoped<DbContext>(sp => sp.GetService<ProjetoPadraoNetCoreDBContext>());
            services.AddTransient<IMeuServicoApplicationService, MeuServicoApplicationService>();
            services.AddTransient<IMeuServicoRepository, MeuServicoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            app.UseMvc();
            app.UseSwagger()
           .UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPadraoNetCore API");
           });
        }
    }
}
