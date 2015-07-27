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
        void Delete(int Id);

        T GetById(int Id);
        List<T> GetAll();
        IQueryable<T> GetAllAsQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
        void Update(T entity);
        T SearchFirst(string searchTerm);

        List<T> SearchToList(string searchTerm);


        List<T> GetListCodeByCodeKindId(int Id);
    }
}
