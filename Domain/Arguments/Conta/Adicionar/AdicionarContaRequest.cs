using System;

namespace Domain.Arguments.Conta
{
    public class AdicionarContaRequest 
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
