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
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.ProductRepository.GetAllItems.ToList();
            }
        }

        public Product Get(int id)
        {
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
