using System;
using CrossCrutting.Enum;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Conta : EntityBase

    {
        public string Nome { get;  set; }
        public double ValorOriginal { get;  set; }
        public  double ValorCorrigido { get; set; }
        public DateTime  DataVencimento  { get;  set; }
        public DateTime DataPagamento { get;  set; }
        public StatusEnum Status { get; set; }
    }
}
