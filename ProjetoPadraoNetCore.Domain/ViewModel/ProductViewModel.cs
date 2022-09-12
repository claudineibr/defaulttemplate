using ProjetoPadraoNetCore.Domain.Classes;
using System;
using System.Collections.Generic;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class ProductViewModel
    {
        private readonly Product product;

        public ProductViewModel(Product product)
        {
            this.product = product;

            if (this.product != null) this.Map();
        }

        private void Map()
        {
            ProductCode = this.product.ProductCode;
            Name = this.product.Name;
            CategoryCode = this.product.CategoryCode;
            CategoryName = this.product.Category != null ? this.product.Category.Name : string.Empty;
            Description = this.product.Description;
            Price = this.product.Price;
            CreateAt = this.product.CreateAt;
            UpdateAt = this.product.UpdateAt;

            Images = new List<ImageViewModel>();
            foreach (var image in this.product.Images)
            {
                Images.Add(new ImageViewModel(image));
            }
        }

        public string ProductCode { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool HasArImage { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public ICollection<ImageViewModel> Images { get; set; }
    }
}
