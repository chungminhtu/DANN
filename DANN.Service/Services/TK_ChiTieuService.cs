using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Model
{

    public class TK_ChiTieuService : EntityService<TK_ChiTieu>
    {
        public TK_ChiTieuService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<TK_ChiTieu>();
        }
    }


}
