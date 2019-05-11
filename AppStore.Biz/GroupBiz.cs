using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.DAL;

namespace AppStore.Biz
{
    public class GroupBiz
    {
        public List<Group> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.GroupRepository.GetAllItems.ToList();
            }
        }

        public Group Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.GroupRepository.GetAllItems.FirstOrDefault(x => x.Id == id);
            }
        }

        public OperationResult Create(Group model)
        {
            OperationResult rState = null;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.GroupRepository.Insert(model, out rState);
                return rState;
            }
        }

        public string Edit(Group model, User user)
        {

            OperationResult state = null;

            Group obj = GetAll().Where(m => m.Id == model.Id).FirstOrDefault();

            LogBiz<Group> log = new LogBiz<Group>();

            string beforeChange = log.GetProperites(obj);

            if (obj != null)
            {
                obj.Name = model.Name;
                obj.Type = model.Type;



                string afterChange = log.GetProperites(obj);

                // unit.GroupRepository.Update(obj, out state);
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.GroupRepository.Update(obj, out state);
                }

                new LogSystemBiz().Insert(new LogSystemModel()
                {
                    Action = "ویرایش گروه",
                    AfterChange = afterChange,
                    BeforeChange = beforeChange,
                    DateTime = DateTime.Now,
                    ErrorMessage = (state.Succeed ? " " : state.Message + " - " + state.Exception.StackTrace),
                    UserId = user.Id.ToString()
                });

                if (state.Succeed)
                    return "true";

                return state.Message;
            }
            return "false";
        }

        public string Delete(Group model, User user)
        {
            OperationResult state = null;
            Group obj = GetAll().Where(m => m.Id == model.Id).FirstOrDefault();

            if (obj != null)
            {
                //  unit.DeviceSettingRepository.Delete(obj, out state);
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.GroupRepository.Delete(obj, out state);
                }

                LogBiz<Group> log = new LogBiz<Group>();
                new LogSystemBiz().Insert(new LogSystemModel()
                {
                    Action = "حذف گروه",
                    AfterChange = log.GetProperites(obj),
                    BeforeChange = "",
                    DateTime = DateTime.Now,
                    ErrorMessage = (state.Succeed ? " " : state.Message + " - " + state.Exception.StackTrace),
                    UserId = user.Id.ToString()
                });

                if (state.Succeed)
                    return "true";
                return state.Message;
            }

            return "false";

        }
    }
}
