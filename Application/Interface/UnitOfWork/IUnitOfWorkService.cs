using Microsoft.EntityFrameworkCore;

namespace Application.Interface.UnitOfWork
{
    public interface IUnitOfWorkService {
        void BeginTransaction();
        void Commit();
    }
}