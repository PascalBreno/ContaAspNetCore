using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.AppService.UnitOfWork;
using Application.Interface.Arguments;
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
      public class AppService <TViewModelRequest, TViewModelResponse, TRequestSearch, TEntity, TService> : UnitOfWorkService, IAppService<TViewModelRequest, TViewModelResponse,TRequestSearch, TEntity>
           where TViewModelRequest : class
           where TViewModelResponse: class
           where TRequestSearch : ISearchRequest<TEntity>
           where TEntity : EntityBase
           where TService : IService<TEntity>
    {
        private readonly TService Service;
        

        public AppService(IUnitOfWork unitOfWork, TService service) : base(unitOfWork)
        {
            Service = service;
        }

        public async Task<TViewModelResponse> Add(TViewModelRequest obj)
        {
            var entity = AutoMapper.Mapper.Map<TEntity>(obj);
            BeginTransaction();
            var result = await Service.Add(entity);
            await Commit();
            return result != null ? AutoMapper.Mapper.Map<TViewModelResponse>(result) : null;
        }

        public TViewModelResponse GetById(Guid id)
        {
            var result = Service.GetById(id);
            return result != default(TEntity) ? AutoMapper.Mapper.Map<TViewModelResponse>(result) : null;
        }
        
        public IEnumerable<TViewModelResponse> GetAll(TRequestSearch requestSearch)
        {
            var result = Service.Get(requestSearch.CriarFiltro());
            return  (result != default(TEntity) ? AutoMapper.Mapper.Map<IEnumerable<TViewModelResponse>>(result) : null);
        }

        
    }
}