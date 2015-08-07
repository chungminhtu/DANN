using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Model
{

    public class DM_DiaPhuongService : EntityService<DM_DiaPhuong>
    {
        public DM_DiaPhuongService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<DM_DiaPhuong>();
        }
    }


}
