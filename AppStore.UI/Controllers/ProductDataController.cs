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
            return Biz.ApiMapper.Map(new Biz.ProductBiz().GetAll());
        }

        // GET api/<controller>/5
        public Product Get(int id)
        {
            var product = new Biz.ProductBiz().Get(id);
            return Biz.ApiMapper.Map(product);
        }

        // POST api/<controller>
        public OperationResult Post([FromBody]Product model)
        {
            var result = new Biz.ProductBiz().Create(model);
            return result;
        }

        [HttpGet]
        public IEnumerable<Product> Search(string Id)
        {
            return Biz.ApiMapper.Map(new Biz.ProductBiz().Find(Id));
        }

        [HttpGet]
        public IEnumerable<Product> NewApps()
        {
            return Biz.ApiMapper.Map(new Biz.ProductBiz().GetAll().OrderByDescending(x => x.DateTime).Take(20).ToList());
        }


        [HttpGet]
        public IEnumerable<Product> MostDownload()
        {
            List<Product> Products = new Biz.ProductBiz().GetAll();
            var Downloads = new Biz.DownloadBiz().GetAll();
            var mostDownload = (from t in Downloads
                                group t by t.Product.Id
                                into g
                                select new
                                {
                                    ProductId = g.Key,
                                    Count = g.Count()
                                }).OrderByDescending(x => x.Count)
                                .Select(x => x.ProductId)
                                .Take(20)
                                .ToList();
            return Biz.ApiMapper.Map(Products.Where(x => mostDownload.Contains(x.Id)).ToList());
        }

    
    }
}