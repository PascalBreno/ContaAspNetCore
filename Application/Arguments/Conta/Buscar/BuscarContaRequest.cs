

using System;
using System.Linq;
using System.Linq.Expressions;
using Application.Interface.Arguments;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Application.Arguments.Conta.Buscar
{
    public class BuscarContaRequest : ISearchRequest<Domain.Entities.Conta>
    {
        public string Nome { get; set; }
        public Expression<Func<Domain.Entities.Conta, bool>>  CriarFiltro ()
        {
            Expression<Func<Domain.Entities.Conta, bool>> filtro = filtro => filtro.IsDeleted == false;
            if (!string.IsNullOrEmpty(Nome))
                filtro = filtro => filtro.Nome == Nome;
            
            return filtro;
        }
        
    }
    
    
 
}
