using AppStore.DAL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public class DownloadBiz
    {
        public List<UserDownload> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

                return uow.UserDownloadRepository.GetAllItems.ToList();
            }
        }

        public OperationResult Create(UserDownload model)
        {
            if (model == null)
                return null;
            model.DateTime = DateTime.Now;
            //todo : set UserID to real value
            model.User_Id = 1;

            OperationResult rState = null;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.UserDownloadRepository.Insert(model, out rState);
                return rState;
            }
        }
    }
}
