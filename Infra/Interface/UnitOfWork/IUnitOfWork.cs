using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}