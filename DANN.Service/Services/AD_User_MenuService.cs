using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class AD_User_MenuService : EntityService<AD_User_Menu>
    {
        public AD_User_MenuService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<AD_User_Menu>();
        }
    }


}
