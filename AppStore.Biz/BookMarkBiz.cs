using AppStore.DAL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public class BookMarkBiz
    {

        public List<BookMark> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.BookMarksRepository.GetAllItems.ToList();
            }
        }
        public OperationResult Create(BookMark model)
        {
            if (model == null)
                return null;
            model.DateTime = DateTime.Now;
            // TODO : SET UserId Real
            model.User_Id = 1;
            OperationResult rState = null;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.BookMarksRepository.Insert(model, out rState);
                return rState;
            }
        }
    }
}
