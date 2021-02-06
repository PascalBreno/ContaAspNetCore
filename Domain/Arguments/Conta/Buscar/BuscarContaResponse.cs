using Domain.Enum;
using Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Conta.Buscar
{
    public class BuscarContaResponse : IResponse
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusEnum status { get; set; }

    }
}
