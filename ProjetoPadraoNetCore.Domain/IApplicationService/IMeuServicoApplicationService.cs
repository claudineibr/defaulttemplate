using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.Domain.IApplicationService
{
    public interface IMeuServicoApplicationService
    {
        Task<MeuServicoViewModel> GetMeuServico(int id);
    }
}
