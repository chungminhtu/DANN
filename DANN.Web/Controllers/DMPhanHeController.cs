using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Model;
using DANN.Service;
namespace DANN.Web.Controllers
{
    public class DMPhanHeController : CommonController<DM_PhanHe, DM_PhanHe, DM_PhanHe>
    {
        public DMPhanHeController(IEntityService<DM_PhanHe> service, IEntityService<DM_PhanHe> service1, IEntityService<DM_PhanHe> service2)
            : base(service, service1, service2)
        {

        }
        
    }
}