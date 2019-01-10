using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProjetoPadraoNetCore.ApplicationService;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.IRepository;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Repository;
using ProjetoPadraoNetCore.Repository.Repositories;
using System;

namespace ProjetoPadraoNetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ProjetoPadraoNetCoreDBContext>(option => option.UseMySql(Config.ConnectionString, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
            }));
            services.AddScoped<DbContext>(sp => sp.GetService<ProjetoPadraoNetCoreDBContext>());
            services.AddTransient<IMeuServicoApplicationService, MeuServicoApplicationService>();
            services.AddTransient<IMeuServicoRepository, MeuServicoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
