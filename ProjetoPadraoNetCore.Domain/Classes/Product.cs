using System;
using System.Collections.Generic;

namespace ProjetoPadraoNetCore.Domain.Classes
{
    public class Product
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
        }

        public string ProductCode { get; set; }
        public string CategoryCode { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Company Company { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
