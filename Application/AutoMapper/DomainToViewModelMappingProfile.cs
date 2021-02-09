using System;
using System.Collections.Generic;
using System.Linq;
using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using CrossCrutting.Enum;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Imea.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, AdicionarContaResponse>().ForMember(x => x.Valor, y => y.MapFrom(z => z.ValorOriginal))
                .ForMember(x=>x.ValorComJuros, y=>y.MapFrom(z=>z.ValorCorrigido))
                .ForMember(x=>x.status,y=> y.MapFrom(z=>Enum.GetName(typeof(StatusEnum), z.status)));



        }
    }
}