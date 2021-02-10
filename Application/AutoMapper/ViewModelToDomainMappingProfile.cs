using Application.Arguments.Conta.Adicionar;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdicionarContaRequest, Conta>().ForMember(x => x.ValorOriginal, y => y.MapFrom(z => z.Valor))
                .ForMember(x => x.ValorCorrigido, y => y.MapFrom(z => z.Valor))
                .ForMember(x => x.DiasDeAtraso,
                    y => y.MapFrom(z =>
                        (z.DataVencimento.HasValue && z.DataPagamento.HasValue)
                            ? ((z.DataPagamento.Value > z.DataVencimento.Value) ? (z.DataPagamento.Value-z.DataVencimento.Value).TotalDays : 0) : 0));
        }
    }
}
