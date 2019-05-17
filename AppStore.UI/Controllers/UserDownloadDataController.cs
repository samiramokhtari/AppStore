using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppStore.Common;
using AppStore.Models;

namespace AppStore.UI.Controllers
{
    public class UserDownloadDataController : ApiController
    {
        // GET: api/UserDownloadData
        public IEnumerable<UserDownload> Get()
        {
            return Biz.ApiMapper.Map(new Biz.DownloadBiz().GetAll());
        }
        
        // POST: api/UserDownloadData
        public OperationResult Post([FromBody]UserDownload model)
        {
            var result = new Biz.DownloadBiz().Create(model);
            return result;
        }

        [HttpGet]
        public int Count(int Id)
        {
            return new Biz.DownloadBiz().GetDownloadCount(Id);
        }
        
    }
}
