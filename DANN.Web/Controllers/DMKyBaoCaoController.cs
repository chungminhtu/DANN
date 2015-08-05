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
        IEntityService<DM_Code> _serviceCode;


        public DMKyBaoCaoController(IEntityService<DM_KyBaoCao> service, IEntityService<DM_KyBaoCao> service1, IEntityService<DM_KyBaoCao> service2, IEntityService<DM_Code> serviceCode)

            : base(service, service1, service2)
        {
            _service = service;
            _serviceCode = serviceCode;
        }
        [ValidateInput(false)]
        public ActionResult LoadKBC()
        {
            ViewBag.ListKyBaoCao = _serviceCode.SearchToList("CodeKind_Id = 3");

            ViewBag.ListKyBaoCao1 = _serviceCode.SearchToList("CodeKind_Id = 4");
            var model = _service.GetAll();
            return PartialView("KyBaoCao", model);
        }
    }
}