using System;
using CrossCrutting.Enum;

namespace Domain.Entities
{
    public class Conta : EntityBase

    {
        public string Nome { get; set; }
        public long ValorOriginal { get; set; }
        public  double? ValorCorrigido { get; set; }
        public DateTime  DataVencimento  { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusEnum status { get; set; }
    }
}
