using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPadraoNetCore.Domain.Classes
{
    public class Category
    {
        public string CategoryCode { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}
