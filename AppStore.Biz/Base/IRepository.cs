using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Transactions;
using System.Data.Linq;

namespace AppStore.Biz
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Fetch(out ResultState rState);
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate, out ResultState rState);
        TEntity First(Func<TEntity, bool> predicate, out ResultState rState);
        void Add(TEntity entity, out ResultState rState);
        void Add(IEnumerable<TEntity> entities, out ResultState rState);
        void Update(TEntity entity, out ResultState rState);
        void Update(TEntity entity, object changes, out ResultState rState);
        void Delete(TEntity entity, out ResultState rState);
        void Delete(IEnumerable<TEntity> entities, out ResultState rState, TransactionScope transactionscope = null);
        void Attach(TEntity entity, out ResultState rState);
        int SaveChanges(out ResultState rState);

        int SaveChanges();
        // int SaveChanges(SaveOptions options, out ResultState rState);
        void SetRecordModificationInfo();
        string GetPkName();
        object GetPkValue(TEntity entity, out ResultState rState);
        DbContext Context { get; set; }
        TEntity GetByPkValue(object pkvalue, out ResultState rState);

        void InsertOnSaveChanges(TEntity entity, out ResultState rState);
        void InsertOnSaveChanges(IEnumerable<TEntity> entities, out ResultState rState);
        void UpdateOnSaveChanges(TEntity entity, out ResultState rState);
        void UpdateOnSaveChanges(TEntity entity, object changes, out ResultState rState);
        void DeleteOnSaveChanges(TEntity entity, out ResultState rState);
        void DeleteOnSaveChanges(IEnumerable<TEntity> entities, out ResultState rState);
    }
}
