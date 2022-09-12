using System;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class JwtTokenViewModel
    {
        public string TokeType { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
