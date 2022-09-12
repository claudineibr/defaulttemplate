using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    class CompanyViewModel
    {
        private readonly Company company;

        public CompanyViewModel(Company company)
        {
            this.company = company;

            if (!(this.company is null)) this.Map();
        }

        private void Map()
        {
            CountryCode = "BR";
            CurrencyType = "BLR";
            Language = "pt-BR";
            CompanyCode = this.company.CompanyCode;
            Name = this.company.Name;
            SmallName = this.company.SmallName;
            LogoUrl = string.IsNullOrEmpty(this.company.LogoUrl) ? string.Empty : string.Format("{0}logos/{1}", Config.EndPointImages, this.company.LogoUrl);
            IsDefault = this.company.IsDefault;
            IsActive = this.company.IsActive;
            PrimaryColor = this.company.PrimaryColor;
            SecondColor = this.company.SecondColor;
            ThirdColor = this.company.ThirdColor;
            CreateAt = this.company.CreateAt;
            UpdateAt = this.company.UpdateAt;
        }

        public string CountryCode { get; set; }
        public string CurrencyType { get; set; }
        public string Language { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string SmallName { get; set; }
        public string LogoUrl { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondColor { get; set; }
        public string ThirdColor { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
