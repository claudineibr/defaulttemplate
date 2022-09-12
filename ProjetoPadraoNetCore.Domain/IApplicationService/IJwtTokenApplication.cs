using ProjetoPadraoNetCore.Domain.ViewModel;

namespace ProjetoPadraoNetCore.Domain.IApplicationService
{
    public interface IJwtTokenApplication
    {
        JwtTokenViewModel BuildToken(BuildTokenViewModel buildToken);
    }
}
