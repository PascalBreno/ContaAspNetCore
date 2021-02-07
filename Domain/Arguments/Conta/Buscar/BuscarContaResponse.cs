using Domain.Enum;
using System;

namespace Domain.Arguments.Conta.Buscar
{
    public class BuscarContaResponse 
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusEnum status { get; set; }

    }
}
