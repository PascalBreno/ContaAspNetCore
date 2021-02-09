using Application.Arguments.Conta.Adicionar;
using Application.Arguments.Conta.Buscar;
using Application.Interface.Base;

namespace Application.Interface.Conta
{
    public interface IContaAppService :IAppService<AdicionarContaRequest, AdicionarContaResponse, BuscarContaRequest, Domain.Entities.Conta>
    {
        
    }
}