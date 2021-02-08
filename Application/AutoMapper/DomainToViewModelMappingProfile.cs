﻿using System.Collections.Generic;
using System.Linq;
using Application.Arguments.Conta.Adicionar;
using AutoMapper;
 using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, AdicionarContaRequest>().ForMember(x=>x.Valor, y=>y.MapFrom(z=>z.ValorOriginal));
            CreateMap<IEnumerable<Conta>, IEnumerable<AdicionarContaResponse>>();
            
          
        }
    }
}