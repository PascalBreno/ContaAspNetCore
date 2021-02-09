using System;
using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using CrossCrutting.Enum;
using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdicionarContaRequest, Conta>().ForMember(x=>x.ValorOriginal, y=>y.MapFrom(z=>z.Valor))
                .ForMember(x=>x.ValorCorrigido,y=>y.MapFrom(z=>z.Valor));
        }
    }
}
