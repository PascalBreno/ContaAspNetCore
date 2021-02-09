using Application.Arguments.Conta.Adicionar;
using Application.Arguments.Conta.Buscar;
using Application.Interface.Conta;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Infra.Persistence;

namespace Application.AppService.Conta
{
    //TViewModel, TEntity, TService, TContext
    public class ContaAppService: Base.AppService<AdicionarContaRequest, AdicionarContaResponse, BuscarContaRequest, Domain.Entities.Conta, IContaService>, IContaAppService
    {
        public ContaAppService(IUnitOfWork unitOfWork, IContaService service) : base(unitOfWork, service)
        {
        }
    }
}