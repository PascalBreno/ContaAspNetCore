using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Interfaces.Services.Base
{
    public interface IService<T>
    where T : EntityBase
    {
        Task<T> Add(T obj);
        
        T GetById(Guid id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);
    }
}