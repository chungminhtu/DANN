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
        IEnumerable<AD_Menu> GetList(int? parentID = null);
    }

    public class AD_MenuService : EntityService<AD_Menu>, IAD_MenuService
    {
        public AD_MenuService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<AD_Menu>();
        }

        public IEnumerable<AD_Menu> GetList(int? parentID = null)
        {
            foreach (var item in GetAll()
                .Where(x => x.ParentId == parentID)
               .OrderBy(x => x.MenuSort)
               .ToList())
            {
                yield return item;

                foreach (var child in GetList(item.Id))
                {
                    yield return child;
                }
            }
        }

    }

}
