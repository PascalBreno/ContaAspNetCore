using Domain.Arguments.Conta;

namespace Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        AdicionarContaResponse AdicionarConta(AdicionarContaRequest conta);
    }
}
