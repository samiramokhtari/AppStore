using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;
using AppStore.DAL;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using AppStore.Models;

namespace AppStore.DAL
{
    public class DataRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class, new()
    {
        public DbContext Context { get; set; }

        protected IDbSet<TEntity> set;

        public DataRepository() :
           // this(new DB_Entities()) { }
            this(null) { }

        public DataRepository(DbContext context)
        {
            this.Context = context;
            var objset = context.Set<TEntity>();
            set = objset;

            // todo: uncomment below lines
            // this.context.CommandTimeout = 90;
            // this.context.ContextOptions.ProxyCreationEnabled = false;
        }

        public IQueryable<TEntity> Fetch(out OperationResult rState)
        {
            try
            {
                var result = set;
                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return null;
            }
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate, out OperationResult rState)
        {
            try
            {
                var result = set.Where(predicate).AsQueryable();
                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return null;
            }
        }

        public TEntity First(Func<TEntity, bool> predicate, out OperationResult rState)
        {
            try
            {
                var result = set.First(predicate);
                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return null;
            }
        }

        public TEntity GetByPkValue(object pkvalue, out OperationResult rState)
        {
            try
            {
                var k = new EntityKeyMember(this.GetPkName(), pkvalue);
                var keyVals = new List<EntityKeyMember>();
                keyVals.Add(k);
                var entitySet = this.getObjSet();
                var entSetName = string.Format("{0}.{1}", entitySet.EntitySet.EntityContainer.Name, entitySet.Name);
                EntityKey key = new EntityKey(entSetName, keyVals);

                var result = (TEntity)entitySet.Context.GetObjectByKey(key);

                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return null;
            }
        }

        public void Add(TEntity entity, out OperationResult rState)
        {
            try
            {
                this.InsertOnSaveChanges(entity, out rState);
                if (!rState.Succeed)
                    throw rState.Exception;
                this.SaveChanges(out rState);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public void Add(IEnumerable<TEntity> entities, out OperationResult rState)
        {
            using (var transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        this.InsertOnSaveChanges(entity, out rState);
                    }
                    this.SaveChanges(out rState);
                    if (!rState.Succeed) throw rState.Exception;
                    transaction.Complete();
                    rState = new OperationResult(null);

                }
                catch (Exception ex)
                {
                    rState = new OperationResult(ex);
                }
            }
        }

        public void Update(TEntity entity, out OperationResult rState)
        {
            try
            {
                this.UpdateOnSaveChanges(entity, out rState);
                if (!rState.Succeed) throw rState.Exception;
                this.SaveChanges(out rState);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public void Update(TEntity entity, object changes, out OperationResult rState)
        {
            try
            {
                this.UpdateOnSaveChanges(entity, changes, out rState);
                if (!rState.Succeed) throw rState.Exception;
                this.SaveChanges(out rState);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public void Delete(TEntity entity, out OperationResult rState)
        {
            try
            {
                this.DeleteOnSaveChanges(entity, out rState);
                if (!rState.Succeed) throw rState.Exception;
                this.SaveChanges(out rState);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }


        public void Delete(IEnumerable<TEntity> entities, out OperationResult rState, TransactionScope transactionscope = null)
        {
            using (var transaction = transactionscope ?? new System.Transactions.TransactionScope())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        this.DeleteOnSaveChanges(entity, out rState);
                    }
                    this.SaveChanges(out rState);
                    if (!rState.Succeed) throw rState.Exception;
                    if (transactionscope == null) transaction.Complete();
                    rState = new OperationResult(null);

                }
                catch (Exception ex)
                {
                    rState = new OperationResult(ex);
                }
            }
        }

        public void Attach(TEntity entity, out OperationResult rState)
        {
            try
            {
                set.Attach(entity);
                this.SaveChanges(out rState);
                rState = new OperationResult(null);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public string GetPkName()
        {
            //  System.Data.Objects.ObjectContext objectContext = ((IObjectContextAdapter)Context).ObjectContext;
            //System.Data.Objects.ObjectSet<TEntity> objSet = objectContext.CreateObjectSet<TEntity>();
            //return objSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).FirstOrDefault();

            return "";
        }

        public System.Data.Objects.ObjectSet<TEntity> getObjSet()
        {
            //  System.Data.Objects.ObjectContext objectContext = ((IObjectContextAdapter)Context).ObjectContext;
            //return objectContext.CreateObjectSet<TEntity>();

            return null;
        }

        public object GetPkValue(TEntity entity, out OperationResult rState)
        {
            try
            {
                var propertyDescriptor = entity.GetType().GetProperty(this.GetPkName());
                var result = propertyDescriptor.GetValue(entity, null);
                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return null;
            }
        }

        public void SetRecordModificationInfo()
        {
            var ctnx = getObjSet().Context;
            var collection = new List<IEnumerable<System.Data.Objects.ObjectStateEntry>>()
            {
                ctnx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added | System.Data.EntityState.Modified | System.Data.EntityState.Unchanged),
                ctnx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified)
            };
            var AllChanges = collection.SelectMany(a => a).OfType<System.Data.Objects.ObjectStateEntry>();

            foreach (System.Data.Objects.ObjectStateEntry item in AllChanges)
            {

                var ModifierUserIdCol = item.Entity.GetType().GetProperty("ModifierUserId");
                var ModifiedDateCol = item.Entity.GetType().GetProperty("ModifiedDate");
                var ModifiedTimeCol = item.Entity.GetType().GetProperty("ModifiedTime");
                var BranchIdCol = item.Entity.GetType().GetProperty("BranchId");
                var pkCol = item.Entity.GetType().GetProperty(this.GetPkName());


                //if (ModifierUserIdCol != null)
                //    ModifierUserIdCol.SetValue(item.Entity,
                //        ModifierUserIdCol.PropertyType.Equals(typeof(Nullable<Guid>)) ? new Nullable<Guid>(Common.CurrentUser.UserId) : Common.CurrentUser.UserId,
                //            null);

                //if (ModifiedDateCol != null)
                //    ModifiedDateCol.SetValue(item.Entity, DateTime.Today.ToShortPersianDate(), null);

                //if (ModifiedTimeCol != null)
                //    ModifiedTimeCol.SetValue(item.Entity,
                //        ModifiedTimeCol.PropertyType.Equals(typeof(Nullable<TimeSpan>)) ? new Nullable<TimeSpan>(DateTime.Now.TimeOfDay) : DateTime.Now.TimeOfDay
                //        , null);

                //if (BranchIdCol != null)
                //    BranchIdCol.SetValue(item.Entity,
                //        BranchIdCol.PropertyType.Equals(typeof(Nullable<Guid>)) ? new Nullable<Guid>(Common.CurrentUser.BranchId) : Common.CurrentUser.BranchId
                //        , null);

                //if (item.State == System.Data.EntityState.Added)
                //    if (pkCol != null)
                //        pkCol.SetValue(item.Entity,
                //            pkCol.PropertyType.Equals(typeof(Nullable<Guid>)) ? new Nullable<Guid>(Guid.NewGuid()) : Guid.NewGuid()
                //            , null);

            }

        }

        public int SaveChanges(out OperationResult rState)
        {
            try
            {
                //SetRecordModificationInfo();
                //Context.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.deleted);

                //var result = context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                var result = Context.SaveChanges();
                rState = new OperationResult(null);
                return result;
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
                return -1;
            }
        }


        public int SaveChanges()
        {
            OperationResult state = null;
            return SaveChanges(out state);
        }


        public void InsertOnSaveChanges(TEntity entity, out OperationResult rState)
        {
            try
            {
                set.Add(entity);
                rState = new OperationResult(null);
                //this.SaveChanges(out rState);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }
        public void InsertOnSaveChanges(IEnumerable<TEntity> entities, out OperationResult rState)
        {
            //using (var transaction = new System.Transactions.TransactionScope())
            //{
            try
            {
                foreach (var entity in entities)
                {
                    this.InsertOnSaveChanges(entity, out rState);
                    if (!rState.Succeed) throw rState.Exception;
                }
                //this.SaveChanges(out rState);
                //transaction.Complete();
                rState = new OperationResult(null);

            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
            //}
        }
        public void UpdateOnSaveChanges(TEntity entity, out OperationResult rState)
        {
            try
            {
                var result = this.GetByPkValue(this.GetPkValue(entity, out rState), out rState);

                System.ComponentModel.PropertyDescriptorCollection originalProps = System.ComponentModel.TypeDescriptor.GetProperties(entity);

                foreach (System.ComponentModel.PropertyDescriptor item in originalProps)
                {
                    if (item.Attributes[typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute)] != null
                        && !(bool)(item.Attributes[typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute)].GetType().GetProperty("EntityKeyProperty")
                        .GetValue(item.Attributes[typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute)], null)))
                    {
                        item.SetValue(result, entity.GetType().GetProperty(item.Name).GetValue(entity, null));
                    }
                }
                entity = result;
                //this.SaveChanges(out rState);
                rState = new OperationResult(null);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public void UpdateOnSaveChanges(TEntity entity, object changes, out OperationResult rState)
        {
            try
            {
                var result = this.GetByPkValue(this.GetPkValue(entity, out rState), out rState);
                if (!rState.Succeed) throw rState.Exception;
                System.ComponentModel.PropertyDescriptorCollection changesProps = System.ComponentModel.TypeDescriptor.GetProperties(changes);

                foreach (System.ComponentModel.PropertyDescriptor item in changesProps)
                {
                    var cVal = changes.GetType().GetProperty(item.Name).GetValue(changes, null);
                    var origProp = result.GetType().GetProperty(item.Name);
                    var origAttr = origProp.GetCustomAttributes(true);

                    if (origAttr.Any(a => a.GetType().Equals(typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute)))
                        && !(bool)(origAttr.First(a => a.GetType().Equals(typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute))).GetType().GetProperty("EntityKeyProperty")
                        .GetValue(origAttr.First(a => a.GetType().Equals(typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute))), null)))
                    {
                        result.GetType().GetProperty(item.Name).SetValue(result, cVal, null);
                    }
                    else if (origAttr.Any(a => a.GetType().Equals(typeof(System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute))))
                    {
                        var cValEnumerable = cVal as IEnumerable<System.Data.Objects.DataClasses.EntityObject>;
                        result.GetType().GetProperty(item.Name).GetValue(result, null).GetType().GetMethod("Clear").Invoke(result.GetType().GetProperty(item.Name).GetValue(result, null), null);
                        foreach (var i in cValEnumerable)
                        {
                            var AppStoremeters = new List<object>();
                            AppStoremeters.Add(i);
                            result.GetType().GetProperty(item.Name).GetValue(result, null).GetType().GetMethod("Add").Invoke(result.GetType().GetProperty(item.Name).GetValue(result, null), AppStoremeters.ToArray());
                        }
                    }
                }
                entity = result;
                rState = new OperationResult(null);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }
        public void DeleteOnSaveChanges(TEntity entity, out OperationResult rState)
        {
            try
            {
                set.Remove(entity);
                rState = new OperationResult(null);
            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }
        public void DeleteOnSaveChanges(IEnumerable<TEntity> entities, out OperationResult rState)
        {
            try
            {
                foreach (var entity in entities)
                {
                    this.DeleteOnSaveChanges(entity, out rState);
                    if (!rState.Succeed) throw rState.Exception;
                }
                rState = new OperationResult(null);

            }
            catch (Exception ex)
            {
                rState = new OperationResult(ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }



        private IEnumerable<string> FindChangedEntityProperties(TEntity entity)
        {
            IEnumerable<string> props = null;
            var cntx = getObjSet().Context;
            var ose = cntx.ObjectStateManager.GetObjectStateEntry(entity);
            if ((entity as System.Data.Objects.DataClasses.EntityObject).EntityState == System.Data.EntityState.Modified)
            {
                ose = cntx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).FirstOrDefault();
                if (ose != null)
                {
                    props = ose.GetModifiedProperties();
                }
            }
            else
            {
                ose = cntx.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added |
                                                                      System.Data.EntityState.Modified
                                                                      ).FirstOrDefault();
                if (ose == null)
                {
                    return null;
                }
                else
                {
                    var stateEntry = cntx.ObjectStateManager.GetObjectStateEntry(ose.Entity);
                    props = (from
                               fm in stateEntry.CurrentValues.DataRecordInfo.FieldMetadata
                             where
                               stateEntry.CurrentValues.IsDBNull(fm.Ordinal) == false
                             select
                               fm.FieldType.Name
                            ).ToArray();
                }
            }
            //Sort (helps with switch statements)
            if (props != null && props.Count() > 0)
            {
                props = props.OrderBy(p => p.ToUpper());
            }

            return props;
        }
    }
}
