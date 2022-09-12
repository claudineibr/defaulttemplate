namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class FilterBaseViewModel
    {
        public FilterBaseViewModel()
        {
            this.Page = 1;
            this.PageSize = 10;
            this.MaxPages = 10;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int MaxPages { get; set; }
    }
}
