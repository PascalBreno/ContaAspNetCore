using System.Threading.Tasks;
using Application.Interface.UnitOfWork;
using Domain.Interfaces.UnitOfWork;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.AppService.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _uow;

        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public async Task<int> Commit()
        {
            return await _uow.SaveChangesAsync();
        }
    }
}