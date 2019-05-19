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

    }
}
