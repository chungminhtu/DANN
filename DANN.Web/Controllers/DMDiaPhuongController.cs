using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Service;
using DANN.Model;
namespace DANN.Web.Controllers
{
    public class DMDiaPhuongController : CommonController<DM_DiaPhuong, DM_DiaPhuong, DM_DiaPhuong>
    {
        public DMDiaPhuongController(IEntityService<DM_DiaPhuong> service, IEntityService<DM_DiaPhuong> service1, IEntityService<DM_DiaPhuong> service2)
            : base(service, service1, service2)
        {

        }
    }
}