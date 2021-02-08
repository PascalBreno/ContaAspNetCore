using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.AppService.UnitOfWork;
using Application.Interface.Base;
using Domain.Entities;
using Domain.Interfaces.Services.Base;
using Domain.Interfaces.UnitOfWork;
using FluentValidation;
using FluentValidation.Results;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.AppService.Base
{
      public class AppService <TViewModel, TEntity, TService> : UnitOfWorkService, IAppService<TViewModel>
           where TViewModel : class
           where TEntity : EntityBase
           where TService : IService<TEntity>
    {
        private readonly TService Service;
        

        public AppService(IUnitOfWork unitOfWork, TService service) : base(unitOfWork)
        {
            Service = service;
        }

        public async Task<TViewModel> Add(TViewModel obj)
        {
            var entity = AutoMapper.Mapper.Map<TEntity>(obj);
            BeginTransaction();
            var result = await Service.Add(entity);
            Commit();
            return result != null ? AutoMapper.Mapper.Map<TViewModel>(result) : null;
        }

        public TViewModel GetById(string id)
        {
            var result = Service.GetById(id);
            return result != default(TEntity) ? AutoMapper.Mapper.Map<TViewModel>(result) : null;
        }
        
        public IEnumerable<TViewModel> GetAll()
        {
            var result = Service.Get();
            return  (result != default(TEntity) ? AutoMapper.Mapper.Map<IEnumerable<TViewModel>>(result) : null);
        }

        
    }
}