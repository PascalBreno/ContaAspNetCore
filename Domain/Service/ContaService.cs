using System;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Service.Base;
using FluentValidation;

namespace Domain.Service
{
    public class ContaService : Service<Conta>, IContaService
    {

        public ContaService(IValidator<Conta> validator, IRepository<Conta> repository) : base(validator, repository)
        {
        }
        
    }
}
