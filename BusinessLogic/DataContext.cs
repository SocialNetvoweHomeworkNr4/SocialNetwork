using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace BusinessLogic.Models
{
    using BusinessLogic.Infrastructure;

    public partial class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
    }

    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}