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
        IEntityService<DM_DonViTinh> _service;
        IEntityService<DM_Code> _serviceCode;

        public DMDonViTinhController(IEntityService<DM_DonViTinh> service, IEntityService<DM_DonViTinh> service1, IEntityService<DM_DonViTinh> service2,         IEntityService<DM_Code> serviceCode)
            : base(service, service1, service2)
        {
            _service = service;
            _serviceCode = serviceCode;
        }

        [ValidateInput(false)]
        public ActionResult LoadDVT()
        {
            ViewBag.ListDonViTinh = _serviceCode.SearchToList("CodeKind_Id = 1");
            var model = _service.GetAll();
            return PartialView("DonViTinh", model);
        }

    }
}