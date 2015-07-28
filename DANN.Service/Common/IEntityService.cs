using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;
using System.Linq.Expressions;

namespace DANN.Service
{
    public interface IEntityService<T> where T : BaseEntity
    {
        void Create(T entity);
        void CreateWithParentID(T entity, int ParentID);
        void Delete(T entity);
        void Update(T entity);
        void UpdateWithParentID(T entity, int ParentID);
        void Move(T entity);

        int MaxId();
        int MaxCodeValue(int CodeKindID);
        T GetById(int Id);
        List<T> GetAll();
        IQueryable<T> GetAllAsQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
        T SearchFirst(string searchTerm);

        List<T> SearchToList(string searchTerm);

    }
}
