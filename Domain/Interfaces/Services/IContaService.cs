using Domain.Arguments.Conta;

namespace Domain.Interfaces.Services
{
    public interface IContaService
    {
        AdicionarContaResponse AdicionarConta(AdicionarContaRequest conta);
    }
}
