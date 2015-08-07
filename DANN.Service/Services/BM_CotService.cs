using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Model
{

    public class BM_CotService : EntityService<BM_Cot>
    {
        public BM_CotService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<BM_Cot>();
        }
    }


}
