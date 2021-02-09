using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interface.Arguments;

namespace Application.Interface.Base
{
    public interface IAppService<T, TResponse, TRequestSearch, TEntity> 
        where T : class
        where TResponse: class
    where TRequestSearch : ISearchRequest<TEntity>
    {
        Task<TResponse> Add(T viewModel);


        IEnumerable<TResponse> GetAll(TRequestSearch filtro);
        TResponse GetById(Guid id);

    }
}