using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Interface.Arguments
{
    public interface ISearchRequest <T>
    {
        Expression<Func<T, bool>>  CriarFiltro();
    }
}