using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;

namespace AppStore.Biz
{
    public class ProductBiz
    {
        public List<Product> GetAll()
        {
            List<Product> result = new List<Product>();
            result.Add(new Product() { Id = 1, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="قورمه" });
            result.Add(new Product() { Id = 2, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="پتزای آنلاین" });
            result.Add(new Product() { Id = 3, Group = new Group() { Id = 1 },DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="بانو" });
            result.Add(new Product() { Id = 4, Group = new Group() { Id = 1 }, DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="فلفل" });
            result.Add(new Product() { Id = 5, Group = new Group() { Id = 1 }, DateTime = DateTime.Now,Price = 0,FileSize = "2k",Name="قورمه" });
            result.Add(new Product() { Id = 6, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "هواشناسی 4" });
            result.Add(new Product() { Id = 7, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "کیفیت هوای تهران" });
            result.Add(new Product() { Id = 8, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "هواشناسی" });
            result.Add(new Product() { Id = 9, Group = new Group() { Id = 2 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "Transparent clock & Weather" });
            result.Add(new Product() { Id = 10, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "تیر اندازی" });
            result.Add(new Product() { Id = 11, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "مبارز" });
            result.Add(new Product() { Id = 12, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "بازی تکاور" });
            result.Add(new Product() { Id = 13, Group = new Group() { Id = 6 }, DateTime = DateTime.Now, Price = 0, FileSize = "2k", Name = "فرمانده" });
            return result;
        }


        public string Edit(Product model, string userId)
        {

            ResultState state = null;

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


        public string Delete(int id, string userId)
        {
            ResultState state = null;
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
