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
    public class DMPhanHeController : CommonController<DM_PhanHe, DM_PhanHe, DM_PhanHe>
    {
        IEntityService<DM_PhanHe> _service;

        public DMPhanHeController(IEntityService<DM_PhanHe> service, IEntityService<DM_PhanHe> service1, IEntityService<DM_PhanHe> service2)
            : base(service, service1, service2)
        {
            _service = service;
        }

        [ValidateInput(false)]
        public ActionResult LoadComboPhanHe(ComboboxModel model)
        {
            ViewData["ComboListPhanHe"] = _service.GetAll();
            return PartialView("_ComboboxPhanHe", model);
        }
    }
}