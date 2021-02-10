using System;
using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using CrossCrutting.Enum;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, AdicionarContaResponse>().ForMember(x => x.Valor, y => y.MapFrom(z => z.ValorOriginal))
                .ForMember(x=>x.ValorComJuros, y=>y.MapFrom(z=>z.ValorCorrigido))
                .ForMember(x=>x.Status,y=> y.MapFrom(z=>Enum.GetName(typeof(StatusEnum), z.Status)))
                .ForMember(x=>x.QuantidadeDeDias, y=>y.MapFrom(z=> (z.DataPagamento>z.DataVencimento) ? (z.DataVencimento-z.DataPagamento).TotalDays : 0));

        }
    }
}