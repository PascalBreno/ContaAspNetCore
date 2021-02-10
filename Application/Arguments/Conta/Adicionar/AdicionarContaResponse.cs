using System;

namespace Application.Arguments.Conta.Adicionar
{
    public class AdicionarContaResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public double ValorComJuros { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Status { get; set; }
    }
}