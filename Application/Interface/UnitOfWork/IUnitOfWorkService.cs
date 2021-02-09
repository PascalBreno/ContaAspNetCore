using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Interface.UnitOfWork
{
    public interface IUnitOfWorkService {
        void BeginTransaction();
        Task<int> Commit();
    }
}