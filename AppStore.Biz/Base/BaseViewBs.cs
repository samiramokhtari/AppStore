using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Linq;

namespace AppStore.Biz
{
    public class BaseViewBs<TEntity> where TEntity : class, new()
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
