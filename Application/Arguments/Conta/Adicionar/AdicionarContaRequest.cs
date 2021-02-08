using System;
using CrossCrutting.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;

namespace Application.Arguments.Conta.Adicionar
{
    public class AdicionarContaRequest 
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string status { get; set; }

    }
}
