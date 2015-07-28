using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;
using System.Linq.Expressions;

namespace DANN.Service
{
    public interface IEntityService<T>
     where T : BaseEntity
    {

        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Move(Int32 Id, Int32? ParentId);

        int MaxId();

        T GetById(int Id);
        List<T> GetAll();
        IQueryable<T> GetAllAsQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
        T SearchFirst(string searchTerm);

        List<T> SearchToList(string searchTerm);


        List<T> GetListCodeByCodeKindId(int Id);
    }
}
