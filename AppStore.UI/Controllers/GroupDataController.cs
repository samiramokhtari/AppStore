using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppStore.UI.Controllers
{
    public class GroupDataController : ApiController
    {
        // GET: api/GroupData
        public IEnumerable<Group> Get()
        {
            return Biz.ApiMapper.Map(new Biz.GroupBiz().GetAll());
        }

        // GET: api/GroupData/5
        public Group Get(int id)
        {
            return Biz.ApiMapper.Map(new Biz.GroupBiz().Get(id));
        }
        

        // Post: api/GroupData/5
        public OperationResult Post([FromBody]Group model)
        {
            var result = new Biz.GroupBiz().Create(model);
            return result;
        }
        
    }
}
