using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppStore.UI.Controllers
{
    public class ProductDataController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            return new Biz.ProductBiz().GetAll();
        }

        // GET api/<controller>/5
        public Product Get(int id)
        {
            return new Biz.ProductBiz().Get(id);
        }

        // POST api/<controller>
        public OperationResult Post([FromBody]Product model)
        {
            var result = new Biz.ProductBiz().Create(model);
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