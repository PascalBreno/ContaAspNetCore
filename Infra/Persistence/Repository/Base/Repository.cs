using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infra.Persistence.Repository.Base
{
    public class Repository<T> : IRepository<T>
    where T : EntityBase 
    {

        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
        public async Task<T> Add(T obj)
        {
            var entry = _context.Entry(obj);
            entry.State = EntityState.Added;
            await _context.SaveChangesAsync();   
            return  entry.Entity;
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
            var dbSet = _context.Set<T>();
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).AsNoTracking();
            return query.AsNoTracking();
        }

        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}