namespace AppStore.DAL
{
    using AppStore.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppStoreDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppStoreDbContext()
            : base("name=AppStoreDbContext", throwIfV1Schema: false)
        {
        }

        public static AppStoreDbContext Create()
        {
            return new AppStoreDbContext();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserDownload> UserDownloads { get; set; }
        public virtual DbSet<SubGroup> SubGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

}