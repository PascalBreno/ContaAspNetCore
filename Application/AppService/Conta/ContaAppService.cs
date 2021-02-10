using Application.Arguments.Conta.Adicionar;
using Application.Arguments.Conta.Buscar;
using Application.Interface.Conta;
using AutoMapper;
using Domain.Interfaces.Services.Base;
using Domain.Interfaces.UnitOfWork;

namespace Application.AppService.Conta
{
    //TViewModel, TEntity, TService, TContext
    public class ContaAppService: Base.AppService<AdicionarContaRequest, AdicionarContaResponse, BuscarContaRequest, Domain.Entities.Conta>, IContaAppService
    {
        public ContaAppService(IUnitOfWork unitOfWork, IService<Domain.Entities.Conta> service, IMapper mapper) : base(unitOfWork, service, mapper)
        {
        }
    }
}