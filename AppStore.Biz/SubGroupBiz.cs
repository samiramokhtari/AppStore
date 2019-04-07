using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
   public class SubGroupBiz
    {


        public List<SubGroup> GetListSubGroup()
        {
            List<SubGroup> result = new List<SubGroup>();
            result.Add(new SubGroup(){Id = 1,Name= "آموزشی" ,GroupId = 2});
            result.Add(new SubGroup(){ Id = 2 , Name ="استراتژی" , GroupId = 2});
            result.Add(new SubGroup(){Id = 3 ,Name = "اکشن", GroupId = 2 });
            result.Add(new SubGroup() { Id = 4, Name = " کسب و کار", GroupId = 1 });
            result.Add(new SubGroup() { Id = 3, Name = "آشپزی", GroupId = 1 });
            result.Add(new SubGroup() { Id = 3, Name = "ورزشی", GroupId = 1 });
            result.Add(new SubGroup() { Id = 3, Name = "رستوران", GroupId = 1 });
            return result; 
        }
    }
}
