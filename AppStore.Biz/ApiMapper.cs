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
        public static Product Map(Product P)
        {
            return new Product()
            {
                Name = P.Name,
                DateTime = P.DateTime,
                Developer = P.Developer,
                FileSize = P.FileSize,
                FileUpload = P.FileUpload,
                Group_Id = P.Group_Id,
                Id = P.Id,
                License = P.License,
                Price = P.Price,
                Rate = P.Rate,
                Version = P.Version
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


        public UserDownload Map(UserDownload ud)
        {
            return new UserDownload() {

                DateTime = ud.DateTime,
                Id = ud.Id,
                Product_Id = ud.Product_Id,
                User_Id = ud.User_Id

            };
        }



        public List<UserDownload> Map(List<UserDownload> list)
        {
            List<UserDownload> result = new List<UserDownload>();
            foreach (var item in result)
            {
                result.Add(Map(item));
            }
            return result;
        }
    }
}
