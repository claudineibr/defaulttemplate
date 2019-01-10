using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Domain.IRepository
{
    public interface IMeuServicoRepository
    {
        MeuServico GetMeuServico(int id);
    }
}
