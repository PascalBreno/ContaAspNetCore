using System.Threading.Tasks;
using CrossCrutting.Enum;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Service.Base;
using FluentValidation;

namespace Domain.Service
{
    public class ContaService : Service<Conta>, IContaService
    {

        public ContaService(IValidator<Conta> validator, IContaRepository repository) : base(validator, repository)
        {
            
        }

        public override async Task<Conta> Add(Conta obj)
        {
            double valorAcrescentado = 0;
            if (obj.DataPagamento > obj.DataVencimento)
            {
                var diasDeAtraso = (obj.DataPagamento - obj.DataVencimento).TotalDays;
                if (diasDeAtraso <= 3)
                    //Cndição para multa de 2% e juros de 0,1% ao dia
                    valorAcrescentado = VerificacaoAcrescimo((int)diasDeAtraso, 2, 0.1, obj.ValorOriginal);
                
                else if (diasDeAtraso > 3 && diasDeAtraso <= 5)
                    //Condição para multa de 3% e juros de 0,2% ao dia
                    valorAcrescentado = VerificacaoAcrescimo((int)diasDeAtraso, 3, 0.2, obj.ValorOriginal);
                
                else if (diasDeAtraso > 5)
                    //Condição para multa de 3% e juros de 0,3% ao dia
                    valorAcrescentado = VerificacaoAcrescimo((int)diasDeAtraso,3, 0.3, obj.ValorOriginal);
                obj.Status = StatusEnum.PagoComAtraso;

            }
            else
                obj.Status = StatusEnum.PagoSemAtraso;

            obj.ValorCorrigido = obj.ValorOriginal + valorAcrescentado;
            return await base.Add(obj);
        }

        public double VerificacaoAcrescimo(int dias, double multa, double juros, double valorOriginal)
        {
            var percentual = multa / 100.0;
            var valorAcrescentado = percentual * valorOriginal;
            juros *= dias;
            percentual = juros/ 100.0;
            return  valorAcrescentado+ percentual * valorOriginal;
        }
    }
}
