using Domain.Interfaces.Arguments;
using System;

namespace Domain.Arguments.Conta
{
    public class AdicionarContaRequest : IRequest
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
