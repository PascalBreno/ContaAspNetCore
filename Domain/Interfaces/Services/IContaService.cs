using System;
using Domain.Arguments.Conta;
using Domain.Entities;
using Domain.Interfaces.Services.Base;

namespace Domain.Interfaces.Services
{
    public interface IContaService: IService<Conta>
    {
        Guid AdicionarConta(AdicionarContaRequest conta);
    }
}
