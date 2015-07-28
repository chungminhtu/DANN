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
    public class DMKyBaoCaoController : CommonController<DM_KyBaoCao, DM_KyBaoCao, DM_KyBaoCao>
    {
        IEntityService<DM_KyBaoCao> _service;

        public DMKyBaoCaoController(IEntityService<DM_KyBaoCao> service, IEntityService<DM_KyBaoCao> service1, IEntityService<DM_KyBaoCao> service2)
            : base(service, service1, service2)
        {
            _service = service;
        }
    }
}