using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.WebApi.Configurations
{
    public static class IdentitySetup
    {
        public static void AddIdentitySetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                      ClockSkew = TimeSpan.Zero
                  };
                  options.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = context =>
                      {
                          if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                          {
                              context.Response.Headers.Add("Token-Expired", "true");
                          }
                          return Task.CompletedTask;
                      }
                  };
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });
        }
    }
}
