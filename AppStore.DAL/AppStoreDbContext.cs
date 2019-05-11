namespace AppStore.DAL
{
    using Migrations;
    using AppStore.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppStoreDbContext : IdentityDbContext<ApplicationUser>
    // public class AppStoreDbContext : DbContext
    {

        public AppStoreDbContext() // :base()
             : base("name=AppStoreDbContext", throwIfV1Schema: false)
        {
            // Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppStoreDbContext, Configuration>());
           
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserDownload> UserDownloads { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BookMark> BookMarks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}