using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Entity.Infrastructure;

namespace DANN.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        public IContext _context { get; set; }
        public IDbSet<T> _dbset { get; set; }

        public string KeyName;

        public EntityService(IContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
            KeyName = typeof(T).GetProperties()[0].Name;
        }

        #region Basic CRUD Functions

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            PropertyInfo pInfo = typeof(T).GetProperties()[0];
            if (pInfo.PropertyType == typeof(int))
            {
                CommonFunctions.TrySetProperty(entity, typeof(T).GetProperties()[0].Name, MaxId() + 1);
            }
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public virtual void CreateWithParentID(T entity, int ParentID)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            CommonFunctions.TrySetProperty(entity, typeof(T).GetProperties()[0].Name, MaxId() + 1);
            CommonFunctions.TrySetProperty(entity, typeof(T).GetProperties()[1].Name, ParentID);
            _dbset.Add(entity);
            _context.SaveChanges();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void InsertOrUpdate(T entity)
        {
            var cEntity = GetEntityById(GetIdGeneric(entity));
            if (cEntity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbset.Add(entity);
            }
            _context.SaveChanges();
        }

        public virtual void InsertOrUpdate2Key(T entity)
        {
            var cEntity = GetEntityBy2Key(GetIdGeneric(entity), GetId1Generic(entity));
            if (cEntity != null)
            {
                var entry = _context.Entry<T>(entity);

                if (entry.State == EntityState.Detached)
                {
                    var set = _context.Set<T>();
                    T attachedEntity = set.Local.AsQueryable<T>().Where(typeof(T).GetProperties()[0].Name + " = @0 and " + typeof(T).GetProperties()[1].Name + " = @1", GetIdGeneric(entity), GetId1Generic(entity)).SingleOrDefault();  // You need to have access to key
                    if (attachedEntity != null)
                    {
                        var attachedEntry = _context.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entry.State = EntityState.Modified; // This should attach entity
                    }
                }
            }
            else
            {
                _dbset.Add(entity);
            }
            _context.SaveChanges();
        }

        public virtual void UpdateWithParentID(T entity, int ParentID)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            CommonFunctions.TrySetProperty(entity, typeof(T).GetProperties()[1].Name, ParentID);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var curentEntity = GetEntityById(GetIdGeneric(entity));
            if (curentEntity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(curentEntity);
            _context.SaveChanges();
        }

        public virtual void DeleteAll(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public void Move(T entity)
        {
            var cEntity = GetEntityById(GetIdGeneric(entity));
            if (cEntity != null)
            {
                object cP = GetParentIdGeneric(entity);
                CommonFunctions.TrySetProperty(cEntity, typeof(T).GetProperties()[1].Name, cP);
            }
            _context.SaveChanges();
        }

        public int MaxId()
        {
            var lastEntity = _dbset.AsEnumerable<T>().LastOrDefault();
            int result = 0;
            if (lastEntity != null)
            {
                var query = typeof(T).GetProperties()[0].GetValue(lastEntity);
                int.TryParse(query + "", out result);
            }
            return result;
        }
        public int MaxCodeValue(int CodeKindID)
        {
            var lastEntity = _dbset.Where("CodeKind_Id = @0", CodeKindID).OrderBy("CodeValue").AsEnumerable<T>().LastOrDefault();
            int result = 0;
            if (lastEntity != null)
            {
                var query = typeof(T).GetProperties()[3].GetValue(lastEntity);
                int.TryParse(query + "", out result);
            }
            return result;
        }

        #endregion

        #region Search Filter Functions

        public virtual List<T> GetAll()
        {
            return _dbset.ToList<T>();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public virtual List<T> GetListById(object Id)
        {
            return _dbset.Where(typeof(T).GetProperties()[0].Name + " = @0", Id).ToList<T>();
        }

        public virtual IQueryable<T> GetAllAsQueryable()
        {
            return _dbset.AsQueryable<T>();

        }
        public virtual IEnumerable<T> GetAllAsIEnumerable()
        {
            return _dbset.AsEnumerable<T>();

        }

        public virtual T GetEntityById(object Id)
        {
            return _dbset.Where(typeof(T).GetProperties()[0].Name + " = @0", Id).FirstOrDefault();
        }

        public virtual T GetEntityBy2Key(object Id1, object Id2)
        {
            return _dbset.Where(typeof(T).GetProperties()[0].Name + " = @0 And " + typeof(T).GetProperties()[1].Name + " = @1", Id1, Id2).FirstOrDefault();
        }

        public virtual T SearchFirst(string searchTerm)
        {
            return _dbset.Where(searchTerm).FirstOrDefault();
        }

        public virtual List<T> SearchToList(string searchTerm)
        {
            return _dbset.Where(searchTerm).ToList();
        }
        public virtual IQueryable<T> WhereIn(object mList, string fieldName)
        {
            return _dbset.Where("@0.Contains(@1)", mList, fieldName);
        }

        #endregion

        #region Support Functions


        //Hàm lấy giá trị Id của 1 entity Generic
        private object GetIdGeneric(T entity)
        {
            var id = typeof(T).GetProperties()[0].GetValue(entity);
            //int result = CommonFunctions.TryParseId(id + "");
            return id;
        }

        private object GetId1Generic(T entity)
        {
            var id = typeof(T).GetProperties()[1].GetValue(entity);
            //int result = CommonFunctions.TryParseId(id + "");
            return id;
        }

        //Hàm lấy giá trị ParentId của 1 entity Generic
        private object GetParentIdGeneric(T entity)
        {
            var id = typeof(T).GetProperties()[1].GetValue(entity);
            // int? result = CommonFunctions.TryParseParentId(id + "");
            return id;
        }


        #endregion
    }
}
