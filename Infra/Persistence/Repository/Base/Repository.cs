using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence.Repository.Base
{
    public abstract class Repository<T> : IRepository<T>
    where T : EntityBase 
    {

        private readonly Context _context;

        protected Repository(Context context)
        {
            _context = context;
        }
        public async Task<T> Add(T obj)
        {
            await _context.AddAsync(obj);
            return  obj;
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