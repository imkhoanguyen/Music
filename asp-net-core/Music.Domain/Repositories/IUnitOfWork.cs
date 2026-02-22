namespace Music.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void Dispose();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task RollbackTransactionAsync();
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}