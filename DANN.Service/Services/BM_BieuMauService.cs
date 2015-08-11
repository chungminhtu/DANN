using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class BM_BieuMauService : EntityService<BM_BieuMau>
    {
        public BM_BieuMauService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<BM_BieuMau>();
        }
    }


}
