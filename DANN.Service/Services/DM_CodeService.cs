using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{
    public interface IDM_CodeService
    {

    }

    public class DM_CodeService : EntityService<DM_Code>, IDM_CodeService
    {
        public DM_CodeService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<DM_Code>();
        }
    }


}
