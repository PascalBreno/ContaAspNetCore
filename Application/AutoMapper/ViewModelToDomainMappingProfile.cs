using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using Domain.Entities;

namespace Imea.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdicionarContaResponse, Conta>().ForMember(x=>x.ValorOriginal, y=>y.MapFrom(z=>z.Valor));
            CreateMap<AdicionarContaRequest, Conta>().ForMember(x=>x.ValorOriginal, y=>y.MapFrom(z=>z.Valor));
  
        }
    }
}
