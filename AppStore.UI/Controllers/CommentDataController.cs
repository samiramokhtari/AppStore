using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppStore.UI.Controllers
{
    public class CommentDataController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<Comment> Get(int Id)
        {
            return Biz.ApiMapper.Map( new Biz.CommentBiz().Get(Id));
        }

        // POST api/<controller>
        public OperationResult Post([FromBody]Comment model)
        {
            var OperationResult = new Biz.CommentBiz().Create(new Comment() { Description = model.Description, Product_Id = model.Product_Id, UserRate = model.UserRate });
            if (!OperationResult.Succeed)
            {
                return OperationResult;
            }
            else
            {
                double rate = new Biz.CommentBiz().GetRate(model.Product_Id);

                Product product = new Biz.ProductBiz().Get(model.Product_Id);

                product.Rate = rate;
                return new Biz.ProductBiz().Edit(product);
            }
        }
        

        [HttpGet]
        public int CommentsCount(int Id)
        {
            return new Biz.CommentBiz().CommnetsCount(Id);
        }
    }
}
