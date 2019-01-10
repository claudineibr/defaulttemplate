namespace ProjetoPadraoNetCore.Domain
{
    public class BaseResponse
    {
        public bool error { get; set; }

        public string errorMessage { get; set; }

        public object data { get; set; }
    }
}
