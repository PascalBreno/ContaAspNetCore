using Domain.Arguments.Conta;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Service
{
    public class ContaService : IContaService
    {

        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public AdicionarContaResponse AdicionarConta(AdicionarContaRequest conta)
        {
            return _contaRepository.AdicionarConta(conta);
        }
    }
}
