using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class BM_DongService : EntityService<BM_Dong>
    {
        public BM_DongService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<BM_Dong>();
        }
    }


}
