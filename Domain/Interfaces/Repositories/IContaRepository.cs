using Domain.Arguments.Conta;
using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        Guid AdicionarConta(ContaEntity conta);
    }
}
