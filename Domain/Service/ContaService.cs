using System;
using System.Threading.Tasks;
using CrossCrutting.Enum;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services;
using Domain.Service.Base;
using FluentValidation;

namespace Domain.Service
{
    public class ContaService : Service<Conta>, IContaService
    {

        public ContaService(IValidator<Conta> validator, IRepository<Conta> repository) : base(validator, repository)
        {
            
        }

        public async Task<Conta> Add(Conta obj)
        {
            double ValorAcrescentado = 0;
            if (obj.DataPagamento > obj.DataVencimento)
            {
                
                //Banco => Obj A : banana, 4 , vinte
                //obj B : Maça, 5 , null
                //Mapping: Maça, 5, null
                var DiasDeAtraso = (obj.DataPagamento - obj.DataVencimento).TotalDays;
                if (DiasDeAtraso <= 3)
                    //Cndição para multa de 2% e juros de 0,1% ao dia
                    //todo Procurar Formatação double 0.1
                    ValorAcrescentado = VerificacaoAcrescimo((int)DiasDeAtraso, 2, 0.1, obj.ValorOriginal);
                
                else if (DiasDeAtraso > 3 && DiasDeAtraso <= 5)
                    //Condição para multa de 3% e juros de 0,2% ao dia
                    ValorAcrescentado = VerificacaoAcrescimo((int)DiasDeAtraso, 3, 0.2, obj.ValorOriginal);
                
                else if (DiasDeAtraso > 5)
                    //Condição para multa de 3% e juros de 0,3% ao dia
                    ValorAcrescentado = VerificacaoAcrescimo((int)DiasDeAtraso,3, 0.3, obj.ValorOriginal);
                obj.status = StatusEnum.PagoComAtraso;

            }
            else
                obj.status = StatusEnum.PagoSemAtraso;

            obj.ValorCorrigido = obj.ValorOriginal + ValorAcrescentado;
            return await base.Add(obj);
        }

        private double VerificacaoAcrescimo(int dias, double multa, double juros, double valorOriginal)
        {
            var percentual = multa / 100.0;
            var ValorAcrescentado = percentual * valorOriginal;
            juros *= dias;
            percentual = juros/ 100.0;
            return  ValorAcrescentado+ percentual * valorOriginal;
        }
    }
}
