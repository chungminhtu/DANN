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

namespace DANN.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        public IContext _context;
        public IDbSet<T> _dbset;

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
            TrySetProperty(entity, typeof(T).GetProperties()[0].Name, MaxId() + 1);
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public virtual void CreateWithParentID(T entity, int ParentID)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            TrySetProperty(entity, typeof(T).GetProperties()[0].Name, MaxId() + 1);
            TrySetProperty(entity, typeof(T).GetProperties()[1].Name, ParentID);
            _dbset.Add(entity);
            _context.SaveChanges();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void UpdateWithParentID(T entity, int ParentID)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            TrySetProperty(entity, typeof(T).GetProperties()[1].Name, ParentID);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var curentEntity = GetById(GetIdGeneric(entity));
            if (curentEntity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(curentEntity);
            _context.SaveChanges();
        }

        public void Move(T entity)
        {
            var cEntity = GetById(GetIdGeneric(entity));
            if (cEntity != null)
            {
                int? cP = GetParentIdGeneric(entity);
                TrySetProperty(cEntity, typeof(T).GetProperties()[1].Name, cP);
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
                var query = typeof(T).GetProperties()[2].GetValue(lastEntity);
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

        public virtual IQueryable<T> GetAllAsQueryable()
        {
            return _dbset.AsQueryable<T>();

        }
        public virtual IEnumerable<T> GetAllAsIEnumerable()
        {
            return _dbset.AsEnumerable<T>();

        }

        public virtual T GetById(int Id)
        {
            return _dbset.Where(typeof(T).GetProperties()[0].Name + " = @0", Id).FirstOrDefault();
        }

        public virtual T SearchFirst(string searchTerm)
        {
            return _dbset.Where(searchTerm).FirstOrDefault();
        }

        public virtual List<T> SearchToList(string searchTerm)
        {
            return _dbset.Where(searchTerm).ToList();
        }

        #endregion

        #region Support Functions

        //Hàm gán giá trị cho thuộc tính generic của 1 object generic
        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }

        //Hàm lấy giá trị Id của 1 entity Generic
        private int GetIdGeneric(T entity)
        {
            var id = typeof(T).GetProperties()[0].GetValue(entity);
            int result = CommonFunctions.TryParseId(id + "");
            return result;
        }

        //Hàm lấy giá trị ParentId của 1 entity Generic
        private int? GetParentIdGeneric(T entity)
        {
            var id = typeof(T).GetProperties()[1].GetValue(entity);
            int? result = CommonFunctions.TryParseParentId(id + "");
            return result;
        }


        #endregion
    }
}
