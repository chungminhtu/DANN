using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class AD_LichSuService : EntityService<AD_LichSu>
    {
        public AD_LichSuService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<AD_LichSu>();
        }
    }


}
