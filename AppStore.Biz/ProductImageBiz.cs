using AppStore.DAL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
   public class ProductImageBiz
    {
        public List<ProductImage> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.ProductImageRepository.GetAllItems.ToList();
            }
        }
    }
}
