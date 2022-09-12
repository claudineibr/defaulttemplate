using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoPadraoNetCore.ApplicationService.AuthenticationService
{
    public class JwtTokenApplication : IJwtTokenApplication
    {
        private readonly IConfiguration _config;

        public JwtTokenApplication(IConfiguration config)
        {
            this._config = config;
        }

        public JwtTokenViewModel BuildToken(BuildTokenViewModel buildToken)
        {
            // Create a claim based on the users emai. You can add more claims like ID's and any other info
            var claims = new[] {
                new Claim(PersonalRegisteredClaimNames.PersonName, buildToken.PersonName),
                new Claim(PersonalRegisteredClaimNames.PersonId, buildToken.PersonId),
                new Claim(PersonalRegisteredClaimNames.CompanyId, buildToken.CompanyId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Creates a key from our private key that will be used in the security algorithm next
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Credentials that are encrypted which can only be created by our server using the private key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime expires = buildToken.ExpireApiKey ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            // this is the actual token that will be issued to the user
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            // return the token in the correct format using JwtSecurityTokenHandler
            return new JwtTokenViewModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = expires,
                TokeType = "bearer"
            };
        }
    }
}
