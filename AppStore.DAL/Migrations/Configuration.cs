namespace AppStore.DAL.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppStore.DAL.AppStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppStore.DAL.AppStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            // context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('dbo.Products', RESEED, 1)");
            //context.Products.AddOrUpdate(new Models.Product()
            //{
            //    Name = "Telegram",
            //    DateTime = DateTime.Now,
            //    Version = 1,
            //    Rate = 0,
            //    Price = 1000,
            //    Developer = "Telegram",
            //    FileSize = "10 MB",
            //    Comments = new List<Comment>()
            //           {
            //               new Comment()
            //               {
            //                    DateTime = DateTime.Now,
            //                    Description = "So great app!",
            //                    UserRate = 5
            //               },
            //               new Comment()
            //               {
            //                    DateTime = DateTime.Now,
            //                    Description = "so fast :)",
            //                    UserRate = 4
            //               }
            //           },
            //    Group = new Group()
            //    {
            //        Name = "بازی",
            //        Type = TypeGroup.Game
            //    },
            //    ProductImages = new List<ProductImage>
            //    {
            //        new ProductImage
            //        {
            //            Type = ImageType.Logo,
            //            ImageName = "telegram.jpg"
            //        },
            //        new ProductImage
            //        {
            //            Type = ImageType.Details,
            //            ImageName = "telegram-page1.jpg"
            //        },

            //    }
            //});

            
        }
    }
}
