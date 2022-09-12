namespace ProjetoPadraoNetCore.Domain
{
    public class BaseResponse<T>
    {
        public bool Sucess { get; set; }
        public object Errors { get; set; }
        public object Data { get; set; }
    }
}
