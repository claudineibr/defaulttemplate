using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ProjetoPadraoNetCore.WebApi.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - HTTP API",
                    Version = "v1",
                    Description = "The Microservice HTTP API.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Claudinei Nascimento",
                        Email = "claudinei@nascorp.com.br"
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API MArketing");
            });
        }
    }
}
