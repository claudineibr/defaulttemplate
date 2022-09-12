using System;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class BuildTokenViewModel
    {
        public string PersonId { get; set; }
        public string CompanyId { get; set; }
        public string PersonName { get; set; }
        public DateTime? ExpireApiKey { get; set; }
    }
}
