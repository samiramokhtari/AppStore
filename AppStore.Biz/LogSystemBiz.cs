using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public class LogSystemBiz
    {
        //UnitOfWork unit = new UnitOfWork();

        public bool Insert(LogSystemModel model)
        {
            ResultState state = null;
            //LogSystem log = new LogSystem()
            //{
            //    Action = (model.Action == null ? "" : model.Action),
            //    AfterChange = (model.AfterChange == null ? "" : model.AfterChange),
            //    BeforeChange = (model.BeforeChange == null ? "" : model.BeforeChange),
            //    DateTime = model.DateTime,
            //    ErrorMessage = (model.ErrorMessage == null ? "" : model.ErrorMessage),
            //    UserId = model.UserId
            //};


            //unit.LogSystemRepository.Insert(log, out state);

            if (state.Succeed)
                return true;
            return false;

        }


        public List<LogSystemModel> GetAll()
        {
            List<LogSystemModel> result = new List<LogSystemModel>();
            //List<LogSystem> list = unit.LogSystemRepository.GetAllItems.ToList();
            //foreach (var item in list)
            //{
            //    result.Add(new LogSystemModel()
            //    {
            //        Action = item.Action,
            //        AfterChange = item.AfterChange,
            //        BeforeChange = item.BeforeChange,
            //        DateTime = item.DateTime,
            //        ErrorMessage = item.ErrorMessage,
            //        UserId = item.UserId,
            //        DateTimeShow = item.DateTime.ToString("yyyy/MM/dd HH:mm:ss")

            //    });
            //}


            //return result.OrderByDescending(x => x.DateTime).ToList();
            return result;
        }


        public List<LogSystemModel> Filter(DateTime? from, DateTime? to)
        {
            var list = GetAll();
            if (from != null)
                list = list.Where(t => t.DateTime >= from).ToList();
            if (to != null)
                list = list.Where(t => t.DateTime <= to).ToList();
            return list;
        }

    }
}
