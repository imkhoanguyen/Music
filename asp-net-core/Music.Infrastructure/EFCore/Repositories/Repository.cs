using Microsoft.EntityFrameworkCore;
using Music.Domain.Repositories;

namespace Music.Infrastructure.EFCore.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected DbContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(MusicContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet;
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
