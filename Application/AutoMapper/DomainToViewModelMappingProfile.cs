using Application.Arguments.Conta.Adicionar;
using AutoMapper;
 using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Conta, AdicionarContaRequest>();
            CreateMap<Conta, AdicionarContaResponse>();
            
          
        }
    }
}