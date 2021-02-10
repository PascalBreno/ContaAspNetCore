using FluentValidation;

namespace Domain.Validator.Conta
{
    public class ContaValidation : AbstractValidator<Entities.Conta>
    {
       public ContaValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório!");
            RuleFor(x => x.ValorOriginal).NotEmpty().WithMessage("O valor da conta deve ser maior que 0");
            RuleFor(x => x.DataVencimento).NotEmpty().WithMessage("A data de vencimento não foi informado");
            RuleFor(x => x.DataPagamento).NotEmpty().WithMessage("A data do pagamento não foi informada");
        }
       
    }
}
