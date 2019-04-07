using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;

namespace AppStore.Biz
{
    public class GroupBiz
    {
        public List<Group> GetAll()
        {
            List<Group> result = new List<Group>();
            result.Add(new Group() { Id = 1,Type = TypeGroup.Application, Name = "آشپزی" });
            result.Add(new Group() { Id = 2,Type = TypeGroup.Application, Name = "آب و هوا" });
            result.Add(new Group() { Id = 3,Type = TypeGroup.Application, Name = "ورزش" });
            result.Add(new Group() { Id = 4,Type = TypeGroup.Game, Name = "آموزشی" });
            result.Add(new Group() { Id = 5,Type = TypeGroup.Game, Name = "استراتژی" });
            result.Add(new Group() { Id = 6,Type = TypeGroup.Game, Name = "اکشن" });
            return result;
        }
    }
}
