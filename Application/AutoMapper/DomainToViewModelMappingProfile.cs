using System;
using System.Collections.Generic;
using System.Linq;
using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using CrossCrutting.Enum;
using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, AdicionarContaRequest>().ForMember(x => x.Valor, y => y.MapFrom(z => z.ValorOriginal));
            //.ForMember(x=>x.status,y=> y.MapFrom(z=>Enum.GetName(typeof(StatusEnum), z.status)));


        }
    }
}