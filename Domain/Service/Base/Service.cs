using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Services.Base;
using FluentValidation;

namespace Domain.Service.Base
{
    public abstract class Service<T> : IService<T>
    where T : EntityBase
    {
        
        private readonly IValidator<T> _validator;
        private readonly IRepository<T> _repository;

        protected Service(IValidator<T> validator, IRepository<T> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public virtual async Task<T> Add(T obj)
        {
            await _validator.ValidateAndThrowAsync(obj);
            return await _repository.Add(obj);
        }
        

        public virtual T GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return _repository.Get(filter);
        }
        
    }
}