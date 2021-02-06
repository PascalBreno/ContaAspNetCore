using Domain.Arguments.Conta;

namespace Domain.Interfaces.Repositories
{
    interface IContaRepository
    {
        AdicionarContaResponse AdicionarConta(AdicionarContaRequest conta);
    }
}
