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

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbset.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
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

        private int GetIdGeneric(T entity)
        {
            var id = typeof(T).GetProperties()[0].GetValue(entity);
            int result = 0;
            int.TryParse(id + "", out result);
            return result;
        }

        public void Move(Int32 Id, Int32? ParentId)
        {
            var entity = GetById(Id);
            if (entity != null)
            {
                TrySetProperty(entity, typeof(T).GetProperties()[1].Name, ParentId);
            }
            _context.SaveChanges();
        }

        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
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

        public virtual List<T> GetListCodeByCodeKindId(int Id)
        {
            return _dbset.Where("CodeKind_Id = @0", Id).ToList();
        }
        public virtual T SearchFirst(string searchTerm)
        {
            return _dbset.Where(searchTerm).FirstOrDefault();
        }

        public virtual List<T> SearchToList(string searchTerm)
        {
            return _dbset.Where(searchTerm).ToList();
        }
    }
}
