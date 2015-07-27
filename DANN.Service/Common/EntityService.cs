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

        public EntityService(IContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
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

        public virtual void Delete(int Id)
        {
            var entity = GetById(Id);
            if (entity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(entity);
            _context.SaveChanges();
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
