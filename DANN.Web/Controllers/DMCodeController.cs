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
    public class DMCodeController : CommonController<DM_CodeKind, DM_Code, DM_Code>
    {
        public DMCodeController(IEntityService<DM_CodeKind> service, IEntityService<DM_Code> service1, IEntityService<DM_Code> service2)
            : base(service, service1, service2)
        {

        }
    }
}