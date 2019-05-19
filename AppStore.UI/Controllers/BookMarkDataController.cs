using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppStore.UI.Controllers
{
    public class BookMarkDataController : ApiController
    {
        
        // POST api/<controller>
        public OperationResult Post([FromBody]int Id)
        {
            return  new Biz.BookMarkBiz().Create(new BookMark() { Product_Id = Id });
        }


    }
}
