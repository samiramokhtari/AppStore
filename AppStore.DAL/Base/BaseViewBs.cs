using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Linq;
using AppStore.Models;

namespace AppStore.DAL
{
    public class BaseViewBs<TEntity> where TEntity : class, IEntity, new()
    {
        private BaseBs<TEntity> bs = new BaseBs<TEntity>();

        public IQueryable<TEntity> GetAllItems
        {
            get
            {
                return bs.GetAllItems;
            }
        }
    }
}
