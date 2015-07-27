using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class AD_UserService : EntityService<AD_User>
    {
        public AD_UserService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<AD_User>();
        }
    }


}
