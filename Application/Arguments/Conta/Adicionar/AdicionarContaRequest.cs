using System;

namespace Application.Arguments.Conta.Adicionar
{
    public class AdicionarContaRequest 
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
