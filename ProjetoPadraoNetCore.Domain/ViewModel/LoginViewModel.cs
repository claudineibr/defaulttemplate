using System;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class LoginViewModel
    {
        public long LoginId { get; set; }
        public long PersonId { get; set; }
        public long StatusId { get; set; }
        public string UserName { get; set; }
        public string Environment { get; set; }

        public TimeSpan AccessStartTime { get; set; }
        public TimeSpan AccessEndTime { get; set; }
        public DateTime ServerDate { get; set; }
        public JwtTokenViewModel ApiToken { get; set; }
    }
}
