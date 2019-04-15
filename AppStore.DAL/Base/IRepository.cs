using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Transactions;
using System.Data.Linq;
using AppStore.Models;

namespace AppStore.DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Fetch(out OperationResult rState);
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate, out OperationResult rState);
        TEntity First(Func<TEntity, bool> predicate, out OperationResult rState);
        void Add(TEntity entity, out OperationResult rState);
        void Add(IEnumerable<TEntity> entities, out OperationResult rState);
        void Update(TEntity entity, out OperationResult rState);
        void Update(TEntity entity, object changes, out OperationResult rState);
        void Delete(TEntity entity, out OperationResult rState);
        void Delete(IEnumerable<TEntity> entities, out OperationResult rState, TransactionScope transactionscope = null);
        void Attach(TEntity entity, out OperationResult rState);
        int SaveChanges(out OperationResult rState);

        int SaveChanges();
        // int SaveChanges(SaveOptions options, out ResultState rState);
        void SetRecordModificationInfo();
        string GetPkName();
        object GetPkValue(TEntity entity, out OperationResult rState);
        DbContext Context { get; set; }
        TEntity GetByPkValue(object pkvalue, out OperationResult rState);

        void InsertOnSaveChanges(TEntity entity, out OperationResult rState);
        void InsertOnSaveChanges(IEnumerable<TEntity> entities, out OperationResult rState);
        void UpdateOnSaveChanges(TEntity entity, out OperationResult rState);
        void UpdateOnSaveChanges(TEntity entity, object changes, out OperationResult rState);
        void DeleteOnSaveChanges(TEntity entity, out OperationResult rState);
        void DeleteOnSaveChanges(IEnumerable<TEntity> entities, out OperationResult rState);
    }
}
