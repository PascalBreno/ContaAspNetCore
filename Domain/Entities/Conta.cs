using System;
using CrossCrutting.Enum;

namespace Domain.Entities
{
    public class Conta : EntityBase

    {
        public string Nome { get; private set; }
        public double ValorOriginal { get; private set; }
        public  double ValorCorrigido { get; set; }
        public DateTime  DataVencimento  { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public StatusEnum status { get; set; }
    }
}
