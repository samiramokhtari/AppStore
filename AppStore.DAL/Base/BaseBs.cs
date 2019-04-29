using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Transactions;
using System.Data;
using AppStore.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AppStore.Models;

namespace AppStore.DAL
{
    public class BaseBs<TEntity> where TEntity : class, new()
    {

        public IRepository<TEntity> Repository;
        public virtual IQueryable<TEntity> GetAllItems
        {
            get
            {
                OperationResult rState = null;
                var table = Repository.Fetch(out rState);

                return table;
            }
        }

        public BaseBs() : this(null) { }

        public BaseBs(DbContext context)
        {
            if (context != null)
                Repository = new DataRepository<TEntity>(context);
            else
                Repository = new DataRepository<TEntity>();
        }

        public BaseBs<TEntity> SetWithLock()
        {
            Repository.Context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
            return this;
        }

        public void SetDbContext(DbContext context)
        {
            this.Repository.Context = context;
            ((IObjectContextAdapter)this.Repository.Context).ObjectContext.CreateObjectSet<TEntity>();
        }
        public DbContext GetDbContext()
        {
            return this.Repository.Context;
        }

        public virtual TEntity Select(object pkvalue, out OperationResult rState)
        {
            var result = Repository.GetByPkValue(pkvalue, out rState);
            return result;
        }

        public virtual TEntity Insert(TEntity entity, out OperationResult rState)
        {
            Repository.Add(entity, out rState);

            return entity;
        }

        public IList<TEntity> Insert(IList<TEntity> entities, out OperationResult rState)
        {
            Repository.Add(entities, out rState);
            return entities;
        }

        public virtual TEntity InsertOnSaveChanges(TEntity entity, out OperationResult rState)
        {
            Repository.InsertOnSaveChanges(entity, out rState);
            return entity;
        }

        public virtual void InsertOnSaveChanges(IList<TEntity> entities, out OperationResult rState)
        {
            Repository.InsertOnSaveChanges(entities, out rState);
        }

        public virtual void DeleteOnSaveChanges(TEntity entity, out OperationResult rState)
        {
            Repository.DeleteOnSaveChanges(entity, out rState);
        }

        public virtual void DeleteOnSaveChanges(object pkvalue, out OperationResult rState)
        {
            var item = this.Select(pkvalue, out rState);
            if (item == null)
            {
                rState = new OperationResult(new Exception("مورد جهت حذف وجود ندارد."), true);
                return;
            }

            Repository.DeleteOnSaveChanges(item, out rState);
        }

        public void DeleteOnSaveChanges(System.Collections.Generic.IEnumerable<TEntity> entities, out OperationResult rState)
        {
            Repository.DeleteOnSaveChanges(entities, out rState);
        }

        public virtual TEntity Update(TEntity entity, out OperationResult rState)
        {
            //if (this.Select(this.Repository.GetPkValue(entity, out rState), out rState) == null)
            //{
            //    rState = new ResultState(new Exception("مورد جهت ویرایش وجود ندارد."), true);
            //    return default(TEntity);
            //}
            Repository.Update(entity, out rState);
            return entity;
        }

        public virtual TEntity Update(TEntity entity, object changes, out OperationResult rState)
        {
            if (this.Select(this.Repository.GetPkValue(entity, out rState), out rState) == null)
            {
                rState = new OperationResult(new Exception("مورد جهت ویرایش وجود ندارد."), true);
                return default(TEntity);
            }

            Repository.Update(entity, changes, out rState);
            return entity;
        }

        public virtual void Delete(TEntity entity, out OperationResult rState)
        {
            Repository.Delete(entity, out rState);
        }

        public virtual void Delete(object pkvalue, out OperationResult rState)
        {
            var item = this.Select(pkvalue, out rState);
            if (item == null)
            {
                rState = new OperationResult(new Exception("مورد جهت حذف وجود ندارد."), true);
                return;
            }

            Repository.Delete(item, out rState);
        }

        public void Delete(System.Collections.Generic.IEnumerable<TEntity> entities, out OperationResult rState, TransactionScope transactionscope = null)
        {
            Repository.Delete(entities, out rState, transactionscope);
        }

        public int SaveChanges(out OperationResult rState)
        {
            return Repository.SaveChanges(out rState);
        }
    }
}
