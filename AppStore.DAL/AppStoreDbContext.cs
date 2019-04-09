namespace AppStore.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppStoreDbContext : DbContext
    {

        public AppStoreDbContext()
            : base("name=AppStoreDbContext")
        {
        }

        public virtual DbSet<Models.Product> Products { get; set; }
        public virtual DbSet<Models.ProductImage> ProductImages { get; set; }
        public virtual DbSet<Models.Comment> Comments { get; set; }
        public virtual DbSet<Models.Group> Groups { get; set; }
        public virtual DbSet<Models.UserDownload> UserDownloads { get; set; }
        public virtual DbSet<Models.SubGroup> SubGroups { get; set; }
        public virtual DbSet<Models.User> Users { get; set; }
    }

}