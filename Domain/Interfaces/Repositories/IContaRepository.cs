using Domain.Arguments.Conta;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Repositories.Base;

namespace Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        Guid AdicionarConta(Conta conta);
    }
}
