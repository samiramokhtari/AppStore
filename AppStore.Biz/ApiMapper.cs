using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public class ApiMapper
    {
        public static Product Map(Product model)
        {
            if (model == null) return null;
            var product = simpleMap(model);
            product.Comments = simpleMap(model.Comments);
            product.Group = simpleMap(model.Group);
            product.ProductImages = simpleMap(model.ProductImages);
            return product;
        }

        private static List<ProductImage> simpleMap(ICollection<ProductImage> list)
        {
            var result = new List<ProductImage>();
            foreach (var item in list)
            {
                result.Add(simpleMap(item));
            }
            return result;
        }

        private static ProductImage simpleMap(ProductImage item)
        {
            return new ProductImage
            {
                Id = item.Id,
                ImageName = item.ImageName,
                Type = item.Type
            };
        }

        private static Group simpleMap(Group group)
        {
            return new Group
            {
                Id = group.Id,
                Name = group.Name,
                Type = group.Type
            };
        }

        private static ICollection<Comment> simpleMap(ICollection<Comment> list)
        {
            var result = new List<Comment>();
            foreach (var item in list)
            {
                result.Add(simpleMap(item));
            }
            return result;
        }

        private static Product simpleMap(Product model)
        {
            return new Product()
            {
                Name = model.Name,
                DateTime = model.DateTime,
                Developer = model.Developer,
                FileSize = model.FileSize,
                FileUpload = model.FileUpload,
                Group_Id = model.Group_Id,
                Id = model.Id,
                License = model.License,
                Price = model.Price,
                Rate = model.Rate,
                Version = model.Version
            };
        }


        

        private static Comment simpleMap(Comment item)
        {
            return new Comment()
            {
                Id = item.Id,
                DateTime = item.DateTime,
                Description = item.Description,
                Product_Id = item.Product_Id,
                UserRate = item.UserRate,
                User_Id = item.User_Id
            };
        }


        public static List<Comment> Map(List<Comment> list)
        {
            var result = new List<Comment>();
            foreach (var item in list)
            {
                result.Add(simpleMap(item));
            }
            return result;
        }

        public static Comment Map(Comment item)
        {
            var comment = simpleMap(item);
            comment.Product = simpleMap(item.Product);
            comment.User = simpleMap(item.User);
            return comment;
        }

        private static User simpleMap(User user)
        {
            return new User() {
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                PhoneNumer = user.PhoneNumer,
                UserName = user.UserName
            };
        }

        public static List<Product> Map(List<Product> list)
        {
            List<Product> result = new List<Product>();
            foreach (var item in list)
            {
                result.Add(Map(item));
            }
            return result;
        }


        public static UserDownload Map(UserDownload model)
        {
            if (model == null) return null;
            return new UserDownload()
            {

                DateTime = model.DateTime,
                Id = model.Id,
                Product_Id = model.Product_Id,
                User_Id = model.User_Id

            };
        }



        public static List<UserDownload> Map(List<UserDownload> list)
        {
            List<UserDownload> result = new List<UserDownload>();
            foreach (var item in result)
            {
                result.Add(Map(item));
            }
            return result;
        }


        public static Group Map(Group model)
        {
            if (model == null) return null;
            return new Group()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type

            };




        }


        public static List<Group> Map(List<Group> list)
        {
            List<Group> result = new List<Group>();
            foreach (var item in list)
            {
                result.Add(Map(item));
            }
            return result;
        }



    }
}
