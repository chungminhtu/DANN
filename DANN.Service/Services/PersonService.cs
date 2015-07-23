using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;
using System.Data.Entity;

namespace DANN.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long Id);
    }

    public class PersonService : EntityService<Person>, IPersonService
    {
        IContext _context;
        public PersonService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Person>();
        }

        //public override IEnumerable<Person> GetAll()
        //{
        //    return _context.Persons.Include(x => x.Country).ToList();
        //}

        public Person GetById(long Id)
        {
            return _dbset.FirstOrDefault(x => x.Id == Id);
        }


    }
}
