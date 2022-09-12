using Microsoft.AspNetCore.Hosting;
using NascorpLib.Security;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.ApplicationService.LoginService
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IJwtTokenApplication _jwtToken;
        private readonly IWebHostEnvironment _env;

        public LoginApplication(IJwtTokenApplication jwtToken,
                                IWebHostEnvironment env)
        {
            _jwtToken = jwtToken;
            _env = env;
        }

        public async Task<LoginViewModel> Authentication(AuthenticationViewModel authentication)
        {
            var crypt = new Cryptography(Constants.KEYCRYPTOGRAPHY);
            var result = new LoginViewModel
            {
                Environment = _env.EnvironmentName,
                ApiToken = _jwtToken.BuildToken(new BuildTokenViewModel()
                {
                    PersonId = crypt.Encrypt("PersonID"),
                    CompanyId = crypt.Encrypt("CompanyId"),
                    PersonName = "Name"
                })
            };

            return await Task.Run(() => result);
        }

        public async Task<LoginViewModel> AuthenticationService(string keyAuthentication)
        {
            var crypt = new Cryptography(Constants.KEYCRYPTOGRAPHY);
            var keyDecript = crypt.Decrypt(keyAuthentication);

            if (!(keyDecript.Contains("@") && keyDecript.Contains(":"))) return null;

            var keys = keyDecript.Split(":");
            var authentication = new AuthenticationViewModel
            {
                UserName = keys[0],
                Password = crypt.Encrypt(keys[1])
            };
            //var login = await loginRepository.Authentication(authentication);
            //if ((login is null)) throw new Exception(Constants.USERNOTFOUND);
            var result = new LoginViewModel()
            {
                Environment = _env.EnvironmentName
            };
            result.ApiToken = _jwtToken.BuildToken(new BuildTokenViewModel()
            {
                PersonId = crypt.Encrypt("PersonID"),
                CompanyId = crypt.Encrypt("CompanyId"),
                PersonName = "Name"
            });
            //  result.ApiToken.RefreshToken = GetRefreshToken(login);
            return await Task.Run(() => result);
        }

        public async Task<LoginViewModel> GetLoginByUserId(long userId)
        {
            var crypt = new Cryptography(Constants.KEYCRYPTOGRAPHY);
            //var login = await loginRepository.GetLoginByUserId(userId);
            //if ((login is null)) throw new Exception(Constants.USERNOTFOUND);
            var result = new LoginViewModel()
            {
                Environment = _env.EnvironmentName
            };
            result.ApiToken = _jwtToken.BuildToken(new BuildTokenViewModel()
            {
                PersonId = crypt.Encrypt("PersonID"),
                CompanyId = crypt.Encrypt("CompanyId"),
                PersonName = "Name"
            });
            //  result.ApiToken.RefreshToken = GetRefreshToken(login);

            return await Task.Run(() => result);
        }

        //private string GetRefreshToken(Login login)
        //{
        //    var crypt = new Cryptography(Constants.KEYCRYPTOGRAPHY);
        //    return crypt.Encrypt(string.Format("{0}:{1}:{2}", login.UserName, crypt.Decrypt(login.Password), new DateTimeOffset(DateTime.Now.AddDays(10)).Ticks));
        //}
    }
}
