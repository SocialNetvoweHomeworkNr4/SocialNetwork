﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public partial class DataContext : LinkMeEntities, IDataContext
    {
    }

    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<User> Users { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<Invintation> Invintations { get; set; }
        int SaveChanges();
    }
}
