using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interface.Arguments;
using Application.Interface.Base;
using AutoMapper;
using Domain.Entities.Base;
using Domain.Interfaces.Services.Base;
using Domain.Interfaces.UnitOfWork;

namespace Application.AppService.Base
{
      public abstract class AppService <TViewModelRequest, TViewModelResponse, TRequestSearch, TEntity> : IAppService<TViewModelRequest, TViewModelResponse,TRequestSearch, TEntity>
           where TViewModelRequest : class
           where TViewModelResponse: class
           where TRequestSearch : ISearchRequest<TEntity>
           where TEntity : EntityBase
    {
        private readonly IService<TEntity> _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected AppService(IUnitOfWork unitOfWork, IService<TEntity> service, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }

        public async Task<TViewModelResponse> Add(TViewModelRequest obj)
        {
            
            var entity = _mapper.Map<TEntity>(obj);
            _unitOfWork.BeginTransaction();
            var result = await _service.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return result != null ? _mapper.Map<TViewModelResponse>(result) : null;
        }

        public TViewModelResponse GetById(Guid id)
        {
            var result = _service.GetById(id);
            return result != default(TEntity) ? _mapper.Map<TViewModelResponse>(result) : null;
        }
        
        public IEnumerable<TViewModelResponse> GetAll(TRequestSearch requestSearch)
        {
            var result = _service.Get(requestSearch.CriarFiltro());
            return  result != null ? _mapper.Map<IEnumerable<TViewModelResponse>>(result) : null;
        }

        
    }
}