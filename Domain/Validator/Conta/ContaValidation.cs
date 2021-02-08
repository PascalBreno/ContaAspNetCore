using FluentValidation;
using System;

namespace Domain.Validator.Conta
{
    public class ContaValidation : AbstractValidator<Entities.Conta>
    {
       public ContaValidation()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome é obrigatório!");
            
            RuleFor(x => x.ValorOriginal).NotNull().WithMessage("O valor da conta não foi informada.");
            RuleFor(x => x.ValorOriginal).Must(valorZero).WithMessage("O valor da conta deve ser maior que 0");
            RuleFor(x => x.DataVencimento).NotNull().WithMessage("A data de vencimento não deve ficar vazia");
            RuleFor(x => x.DataVencimento).Must(DataMaior).WithMessage("A data de vencimento não pode ser menor ou igual a data de hoje.");
            
        }

       private static bool valorZero(long ValorOriginal)
       {
           return ValorOriginal <0.0;
       }
       private static bool DataMaior(DateTime DataVencimento)
       {
           var dataAtual = DateTime.UtcNow;
           return dataAtual < DataVencimento;
       }
    }
}
