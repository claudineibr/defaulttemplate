using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.IRepository;
using ProjetoPadraoNetCore.Domain.ViewModel;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.ApplicationService
{
    public class MeuServicoApplicationService : IMeuServicoApplicationService
    {
        private readonly IMeuServicoRepository meuServicoRepository;

        public MeuServicoApplicationService(IMeuServicoRepository _meuServicoRepository)
        {
            this.meuServicoRepository = _meuServicoRepository;
        }

        public async Task<MeuServicoViewModel> GetMeuServico(int id)
        {
            return new MeuServicoViewModel();
        }
    }
}
