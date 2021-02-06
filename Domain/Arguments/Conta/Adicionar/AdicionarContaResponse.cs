using Domain.Enum;
using Domain.Interfaces.Arguments;
using System;

namespace Domain.Arguments.Conta
{
    public class AdicionarContaResponse : IResponse
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusEnum status { get; set; }

    }
}
