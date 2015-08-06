using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class View_ThongKeNienGiamService : EntityService<View_ThongKeNienGiam>
    {
        public View_ThongKeNienGiamService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<View_ThongKeNienGiam>();
        }
    }


}
