using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BusinessLogic.Models
{
    public partial class DataContext : DbContext, IDataContext
    {
      public DbSet<users> Users { get; set; }

    }

    public interface IDataContext
    {      
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<users> Users { get; set; }
        int SaveChanges();
    }
}