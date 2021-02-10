

using System;
using System.Linq.Expressions;
using Application.Interface.Arguments;

namespace Application.Arguments.Conta.Buscar
{
    public class BuscarContaRequest : ISearchRequest<Domain.Entities.Conta>
    {
        public string Nome { get; set; }
        public Expression<Func<Domain.Entities.Conta, bool>>  CriarFiltro ()
        {
            Expression<Func<Domain.Entities.Conta, bool>> filtro = filter=>true;
            if (!string.IsNullOrEmpty(Nome))
                filtro = x => x.Nome == Nome;
            
            return filtro;
        }
        
    }
    
    
 
}
