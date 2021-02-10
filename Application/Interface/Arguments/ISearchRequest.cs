using System;
using System.Linq.Expressions;

namespace Application.Interface.Arguments
{
    public interface ISearchRequest <T>
    {
        Expression<Func<T, bool>>  CriarFiltro();
    }
}