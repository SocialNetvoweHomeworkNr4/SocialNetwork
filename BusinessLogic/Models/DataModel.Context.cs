﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BusinessLogic.Models
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    

    public partial class LinkMeEntities : DbContext
    {
        public LinkMeEntities()
            : base("name=LinkMeEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<UserImageComment> UserImageComments { get; set; }
        public virtual DbSet<Invintation> Invintations { get; set; }
        public virtual DbSet<UserImageComment> UserImageComments { get; set; }
    }

}

