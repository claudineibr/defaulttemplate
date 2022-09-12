using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace ProjetoPadraoNetCore.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Routing.EndpointMiddleware", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Internal.WebHost", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authorization.DefaultAuthorizationService", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc.StatusCodeResult", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker", LogEventLevel.Warning)
                .MinimumLevel.Override("System.Net.Http.HttpClient.NotificationClient.LogicalHandler", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                 .WriteTo.File(@"logs\api_log_.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 5000000)
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
        .UseShutdownTimeout(TimeSpan.FromSeconds(10))
        .UseStartup<Startup>()
        .SuppressStatusMessages(true) //disable the status messages
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseSerilog()
        .ConfigureAppConfiguration((hostContext, config) =>
        {
            config.Sources.Clear();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
            config.AddEnvironmentVariables();
        });
    }
}
