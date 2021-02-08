using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services.Base
{
    public interface IService<T>
    where T : EntityBase
    {
        Task<T> Add(T obj);

        long GenerateId();

        T GetById(string id);
        T Update(T obj);
        void Remove(T obj);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        bool Any(Expression<Func<T, bool>> filter = null);
    }
}