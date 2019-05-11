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
    }
}
