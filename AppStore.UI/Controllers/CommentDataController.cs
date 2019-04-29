using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class CommentDataController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<Comment> Get(int Productid)
        {
            return new Biz.CommentBiz().Get(Productid);
        }

        // POST api/<controller>
        public OperationResult Post([FromBody]Comment model)
        {
            var result = new Biz.CommentBiz().Create(model);
            return result;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
