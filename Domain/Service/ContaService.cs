using System;
using Domain.Arguments.Conta;
using Domain.Entities;
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

        public Guid AdicionarConta(AdicionarContaRequest conta)
        {
            var teste = new Conta();
            return _contaRepository.AdicionarConta(teste);
        }
    }
}
