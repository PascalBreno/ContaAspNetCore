using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces.UnitOfWork;
using Infra.Persistence;

namespace Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly Context _dbContext;
        private bool _disposed;

        public UnitOfWork(Context context)
        {
            _dbContext = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}