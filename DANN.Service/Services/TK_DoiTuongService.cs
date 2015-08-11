using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{

    public class TK_DoiTuongService : EntityService<TK_DoiTuong>
    {
        public TK_DoiTuongService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<TK_DoiTuong>();
        }
    }


}
