using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Domain.Utilities;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class ImageViewModel
    {
        private readonly Image image;
        public string ImageCode { get; set; }
        public string Name { get; set; }
        public bool Initial { get; set; }
        public string Url { get; set; }

        public ImageViewModel(Image image)
        {
            this.image = image;
            if (this.image != null) this.Map();
        }

        private void Map()
        {
            ImageCode = this.image.ImageCode;
            Name = this.image.Name;
            Url = GetUrl(this.image);
        }

        private string GetUrl(Image image)
        {
            return string.Format("{0}products/{1}", Config.EndPointImages, this.image.Url);
        }
    }
}
