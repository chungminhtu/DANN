using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;
using System.Linq.Expressions;

namespace DANN.Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        void Create(T entity);
        void Delete(int Id);

        T GetById(int Id);

        List<T> GetAll();
        void Update(T entity);
        T FindBy(Expression<Func<T, bool>> predicate);
    }
}
