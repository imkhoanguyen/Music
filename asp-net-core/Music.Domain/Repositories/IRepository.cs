namespace Music.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        IQueryable<TEntity> Query();
        void Remove(TEntity entity);
    }
}
