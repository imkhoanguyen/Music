using Microsoft.EntityFrameworkCore;
using Music.Domain.Entities;

namespace Music.Infrastructure.EFCore
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base(options)
        {
            
        }

        #region DbSets

        public DbSet<Genre> Genres { get; set; }

        #endregion DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
