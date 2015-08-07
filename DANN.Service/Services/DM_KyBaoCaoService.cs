using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Model
{

    public class DM_KyBaoCaoService : EntityService<DM_KyBaoCao>
    {
        public DM_KyBaoCaoService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<DM_KyBaoCao>();
        }
    }


}
