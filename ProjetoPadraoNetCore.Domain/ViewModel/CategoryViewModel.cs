using ProjetoPadraoNetCore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class CategoryViewModel
    {
        private readonly Category category;

        public CategoryViewModel(Category category)
        {
            this.category = category;

            if (!(this.category is null)) this.Map();
        }

        private void Map()
        {
            CategoryCode = this.category.CategoryCode;
            CompanyCode = this.category.CompanyCode;
            Name = this.category.Name;
        }

        public string CategoryCode { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
    }
}
