using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int Id);
    }
}
