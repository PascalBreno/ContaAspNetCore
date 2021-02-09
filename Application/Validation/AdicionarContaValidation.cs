using Application.Arguments.Conta.Adicionar;
using FluentValidation;

namespace Domain.Validator.Conta
{
    public class AdicionarContaValidation: AbstractValidator<AdicionarContaRequest>
    {
        public AdicionarContaValidation()
        {
            
        }
    }
}