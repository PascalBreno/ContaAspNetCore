﻿using Domain.Enum;
using System;

namespace Domain.Entities
{
    public class Conta

    {
        public Guid ContaId { get; set; }
        public string Nome { get; set; }
        public long ValorOriginal { get; set; }
        public  long? ValorCorrigido { get; set; }
        public DateTime  DataVencimento  { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusEnum status { get; set; }


    }
}