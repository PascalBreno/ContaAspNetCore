using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdicionarContaResponse, Conta>();
            CreateMap<AdicionarContaRequest, Conta>();
  
        }
    }
}
