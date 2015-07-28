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
    public class DMDonViTinhController : CommonController<DM_DonViTinh, DM_DonViTinh, DM_DonViTinh>
    {
        // IEntityService<DM_DonViTinh> _service;

        public DMDonViTinhController(IEntityService<DM_DonViTinh> service, IEntityService<DM_DonViTinh> service1, IEntityService<DM_DonViTinh> service2)
            : base(service, service1, service2)
        {
            //  _service = service;
        }
    }
}