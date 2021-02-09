using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> 
    where T : EntityBase
    {
        Task<T> Add(T obj);


        T GetById(Guid id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);
        
    }
}