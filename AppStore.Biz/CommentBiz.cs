using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.DAL;

namespace AppStore.Biz
{
    public class CommentBiz
    {
        public List<Comment> Get(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                return unit.CommentReppository.GetAllItems.Where(x => x.Product_Id == id).ToList();
            }
        }

        public int CommnetsCount(int ProductId)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                return unit.CommentReppository.GetAllItems.Count(x => x.Product_Id == ProductId);
            }
        }

        public OperationResult Create(Comment model)
        {
            if (model == null || model.Description == "")
                return null;

            OperationResult rState = null;
            model.DateTime = DateTime.Now;
            //TODO :SET DATA REAL
            model.User_Id = 1;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.CommentReppository.Insert(model, out rState);
                return rState;
            }
        }


        public double GetRate(int productId)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                return unit.CommentReppository.GetAllItems.Where(x => x.Product_Id == productId && x.UserRate > 0).Select(x => x.UserRate).Average();
            }
        }

    }
}

