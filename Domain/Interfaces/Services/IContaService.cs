using System;
using Domain.Arguments.Conta;

namespace Domain.Interfaces.Services
{
    public interface IContaService
    {
        Guid AdicionarConta(AdicionarContaRequest conta);
    }
}
