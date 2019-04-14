using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.DAL;

namespace AppStore.Biz
{
    public class ProductBiz
    {
        public List<Product> GetAll()
        {
            // todo: uncomment sample data lines
            List<Product> result = new List<Product>();
            result.Add(new Product() { Id = 1, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="قورمه", Logo = new ProductImage() { Id = 1 } });
            result.Add(new Product() { Id = 2, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="پتزای آنلاین" , Logo = new ProductImage() { Id = 2 } });
            result.Add(new Product() { Id = 3, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="بانو" , Logo = new ProductImage() { Id = 3 } });
            result.Add(new Product() { Id = 4, Group = new Group() { Id = 1 }, DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="فلفل" , Logo = new ProductImage() { Id = 4 } });
            result.Add(new Product() { Id = 5, Group = new Group() { Id = 1 }, DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="قورمه" , Logo = new ProductImage() { Id = 5 } });
            result.Add(new Product() { Id = 6, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "هواشناسی 4" , Logo = new ProductImage() { Id = 5 } });
            result.Add(new Product() { Id = 7, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "کیفیت هوای تهران" , Logo = new ProductImage() { Id = 6 } });
            result.Add(new Product() { Id = 8, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "هواشناسی" , Logo = new ProductImage() { Id = 7 } });
            result.Add(new Product() { Id = 9, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "Transparent clock & Weather" , Logo = new ProductImage() { Id = 8 } });
            result.Add(new Product() { Id = 10, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "تیر اندازی" , Logo = new ProductImage() { Id = 9 } });
            result.Add(new Product() { Id = 11, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "مبارز" , Logo = new ProductImage() { Id = 10 } });
            result.Add(new Product() { Id = 12, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "بازی تکاور" , Logo = new ProductImage() { Id = 11 } });
            result.Add(new Product() { Id = 13, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "فرمانده" , Logo = new ProductImage() { Id = 12 } });
            return result;

            // real code
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.ProductRepository.GetAllItems.ToList();
            }


        }

        public Product Get(int id)
        {
            // todo: uncomment sample data lines
            return new Product() { Id = 1, Group = new Group() { Id = 1 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "قورمه", Logo = new ProductImage() { Id = 1 } };

            // real code
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.ProductRepository.GetAllItems.FirstOrDefault(x => x.Id == id);
            }
        }

        public OperationResult Create(Product model)
        {
            OperationResult rState = null;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ProductRepository.Insert(model, out rState);
                return rState;
            }
        }



        /*
        public string Create(Product model, string userId)
        {
            ResultState state = null;

            Product obj = GetAll().Where(m => m.Name == model.Name).FirstOrDefault();

            LogBiz<Product> log = new LogBiz<Product>();


            if (obj == null)
            {
                obj = new Product();
                obj.Name = model.Name;
                obj.Price = model.Price;
                obj.FileSize = model.FileSize;
                obj.DateTime= DateTime.Now;

               // Product newobj = unit.DeviceSettingRepository.Insert(obj, out state);

                new LogSystemBiz().Insert(new LogSystemModel()
                {
                    Action = "اضافه محصول",
                    //AfterChange = log.GetProperites(newobj),
                    BeforeChange = "",
                    DateTime = DateTime.Now,
                    ErrorMessage = (state.Succeed ? " " : state.Message + " - " + state.Exception.StackTrace),
                    UserId = userId
                });
                if (state.Succeed)
                    return "true";



                return state.Message;
            }

            return "false";
        }
        */

        public string Edit(Product model, string userId)
        {

            OperationResult state = null;

            Product obj = GetAll().Where(m => m.Id == model.Id).FirstOrDefault();

            LogBiz<Product> log = new LogBiz<Product>();

            string beforeChange = log.GetProperites(obj);

            if (obj != null)
            {
                obj.Name = model.Name;
                obj.Price = model.Price;



                string afterChange = log.GetProperites(obj);

                // unit.ProductRepository.Update(obj, out state);


                new LogSystemBiz().Insert(new LogSystemModel()
                {
                    Action = "ویرایش محصول",
                    AfterChange = afterChange,
                    BeforeChange = beforeChange,
                    DateTime = DateTime.Now,
                    ErrorMessage = (state.Succeed ? " " : state.Message + " - " + state.Exception.StackTrace),
                    UserId = userId
                });

                if (state.Succeed)
                    return "true";

                return state.Message;
            }
            return "false";
        }




        public string Delete(int id, string userId)
        {
            OperationResult state = null;
            Product obj = GetAll().Where(m => m.Id == id).FirstOrDefault();

            if (obj != null)
            {
              //  unit.DeviceSettingRepository.Delete(obj, out state);
                LogBiz<Product> log = new LogBiz<Product>();
                new LogSystemBiz().Insert(new LogSystemModel()
                {
                    Action = "حذف محصول",
                    AfterChange = log.GetProperites(obj),
                    BeforeChange = "",
                    DateTime = DateTime.Now,
                    ErrorMessage = (state.Succeed ? " " : state.Message + " - " + state.Exception.StackTrace),
                    UserId = userId
                });

                if (state.Succeed)
                    return "true";
                return state.Message;
            }

            return "false";

        }
    }
}
