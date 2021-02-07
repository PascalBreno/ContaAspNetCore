using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infra.Persistence.Repository.Base
{
    public class Repository<T> : IBaseRepository<T>
    where T : class 
    {

        private readonly Context db;

        public Repository(IDbContextFactory<Context> contextFactory)
        {
            db = contextFactory.CreateDbContext();    
        }
        public T Add(T obj)
        {
            var entry = db.Entry(obj);
            entry.State = EntityState.Added;
            return entry.Entity;
        }

        public long GenerateId()
        {
            throw new NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new NotImplementedException();
        }

        public T Update(T obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}