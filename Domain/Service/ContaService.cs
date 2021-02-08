using System;
using System.Threading.Tasks;
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

        public async Task<Conta> Add(Conta obj)
        {
            if (obj.DataPagamento <= obj.DataVencimento) return await base.Add(obj);
            var DiasDeAtraso = (obj.DataPagamento - obj.DataVencimento).TotalDays;
            if (DiasDeAtraso <= 3)
            {
                //Cndição para multa de 2% e juros de 0,1% ao dia
            }
            else if (DiasDeAtraso > 3 && DiasDeAtraso <= 5)
            {
                //Condição para multa de 3% e juros de 0,2% ao dia
            }
            else if (DiasDeAtraso > 5)
            {
                //Condição para multa de 3% e juros de 0,3% ao dia
            }

            return await base.Add(obj);
        }
    }
}
