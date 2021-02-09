using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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
        
        public T GetById(Guid id)
        {
            var dbSet = _context.Set<T>();
            return dbSet.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            var dbSet = _context.Set<T>();
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsNoTracking();
        }
        
    }
}