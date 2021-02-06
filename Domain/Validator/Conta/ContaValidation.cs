using Domain.Arguments.Conta;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator.Conta
{
    public class ContaValidation : AbstractValidator<AdicionarContaRequest>
    {
       public ContaValidation()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome é obrigatório!");
        }
    }
}
