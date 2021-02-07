using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services.Base;
using FluentValidation;

namespace Domain.Service.Base
{
    public class Service<T> : IService<T>
    where T : EntityBase
    {
        
        protected readonly IValidator<T> _validator;
        protected readonly IRepository<T> _repository;

        public Service(IValidator<T> validator, IRepository<T> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public T Add(T obj)
        {
            _validator.ValidateAndThrow(obj);
            return _repository.Add(obj);
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