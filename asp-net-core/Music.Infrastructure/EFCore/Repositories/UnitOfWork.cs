using Microsoft.EntityFrameworkCore.Storage;
using Music.Domain.Repositories;

namespace Music.Infrastructure.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly MusicContext _context;
        private IDbContextTransaction _dbContextTransaction;
        private bool _disposed;

        public UnitOfWork(MusicContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(Repository<TEntity>);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)this._repositories[type];
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task BeginTransactionAsync()
        {
            _dbContextTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_dbContextTransaction != null)
                await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_dbContextTransaction != null)
                await _dbContextTransaction.RollbackAsync();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // equal: _dbContextTransaction?.Dispose();
                    if (_dbContextTransaction != null)
                        _dbContextTransaction.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
