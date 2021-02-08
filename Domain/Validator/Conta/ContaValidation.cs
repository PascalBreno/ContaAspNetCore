using FluentValidation;
using System;

namespace Domain.Validator.Conta
{
    public class ContaValidation : AbstractValidator<Entities.Conta>
    {
       public ContaValidation()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome é obrigatório!");
            RuleFor(x => x.ValorOriginal).NotNull().WithMessage("O Valor original deve ser preenchido");
            RuleFor(x => x.DataVencimento).NotNull().WithMessage("A data de vencimento não deve ficar vazia");
            RuleFor(x => x.DataVencimento).Must(DataMaior).WithMessage("A data de vencimento não pode ser menor ou igual a data de hoje.");
            
        }

       private static bool DataMaior(DateTime DataVencimento)
       {
           var dataAtual = DateTime.UtcNow;
           return dataAtual < DataVencimento;
       }
    }
}
