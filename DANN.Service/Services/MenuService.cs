using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;

namespace DANN.Service
{
    public interface IAD_MenuService : IEntityService<AD_Menu>
    {
        AD_Menu GetById(int Id);
    }


    public class AD_MenuService : EntityService<AD_Menu>, IAD_MenuService
    {
        IContext _context;

        public AD_MenuService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<AD_Menu>();
        }

        public AD_Menu GetById(int Id)
        {
            return _dbset.FirstOrDefault(x => x.Id == Id);
        }
    }


}
