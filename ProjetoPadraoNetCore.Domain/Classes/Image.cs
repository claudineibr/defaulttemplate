namespace ProjetoPadraoNetCore.Domain.Classes
{
    public class Image
    {
        public string ImageCode { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Product Product { get; set; }
    }
}
