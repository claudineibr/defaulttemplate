using ProjetoPadraoNetCore.Domain.ViewModel;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.Domain.IApplicationService
{
    public interface ILoginApplication
    {
        Task<LoginViewModel> Authentication(AuthenticationViewModel authentication);
        Task<LoginViewModel> AuthenticationService(string keyAuthentication);
        Task<LoginViewModel> GetLoginByUserId(long userId);
    }
}
