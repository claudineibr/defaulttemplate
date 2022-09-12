using Amazon.S3;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Net.Http.Headers;
using NascorpLib.WebSocketManager;
using ProjetoPadraoNetCore.WebApi.Configurations;
using ProjetoPadraoNetCore.WebApi.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace ProjetoPadraoNetCore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.WriteIndented = false;
                    o.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            // Add framework services.
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = "https://contoso.com/probs/modelvalidation",
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });

            //enable manager websocket
            //services.AddWebSocketManager();

            //ENABLE SERVICES AWS
            //services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            //services.AddAWSService<IAmazonS3>();
            services.AddSwaggerSetup();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddFilter<ConsoleLoggerProvider>
                    ((category, level) => category == "A" || level == LogLevel.Critical);
            });

            services.AddDatabaseSetup(Configuration);

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDependencyInjectionSetup();
            services.AddDependencyInjectionRabbitSetup(Configuration);
            services.AddIdentitySetup(Configuration);
            services.AddOptions();

            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var defaultDateCulture = "pt-BR";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.CurrencyDecimalSeparator = ",";

            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo> { ci },
                SupportedUICultures = new List<CultureInfo> { ci }
            });

            app.UseCors("AllowAll");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDeveloperExceptionPage();
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromHours(23)
                    };
                context.Response.Headers[HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            app.ConfigureEventBus();
        }
    }
}
