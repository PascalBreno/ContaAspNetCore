using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services.Base;
using FluentValidation;

namespace Domain.Service.Base
{
    public class Service<T> : IService<T>
    where T : EntityBase
    {
        
        private readonly IValidator<T> _validator;
        private readonly IRepository<T> _repository;

        public Service(IValidator<T> validator, IRepository<T> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<T> Add(T obj)
        {
            await _validator.ValidateAndThrowAsync(obj);
            return await _repository.Add(obj);
        }

        public long GenerateId()
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
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