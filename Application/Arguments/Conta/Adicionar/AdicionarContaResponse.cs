using System;
using CrossCrutting.Enum;

namespace Application.Arguments.Conta.Adicionar
{
    public class AdicionarContaResponse 
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusEnum status { get; set; }

    }
}
