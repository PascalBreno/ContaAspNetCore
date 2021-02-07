using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces.Services.Base
{
    public interface IService<T>
    where T : EntityBase
    {
        T Add(T obj);

        long GenerateId();

        T GetById(long id);
        T Update(T obj);
        void Remove(T obj);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        bool Any(Expression<Func<T, bool>> filter = null);
    }
}