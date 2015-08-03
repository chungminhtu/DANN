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
    public class BDBieuDoController : Controller
    {
        DANNEntities db = new DANNEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComboBoxKBCPartial()
        {

            var Model = db.DM_KyBaoCao.ToList();
            return PartialView("_ComboBoxKBCPartial", Model);
        }
        public ActionResult ComboBoxPhanHePartial()
        {

            var Model = db.DM_PhanHe.ToList();
            return PartialView("_ComboBoxPhanHePartial", Model);
        }


        [ValidateInput(false)]
        public ActionResult TreeListChiTieuPartial()
        {
            var Model = db.TK_ChiTieu.ToList();
            return PartialView("_TreeListChiTieuPartial", Model);
        }
        [ValidateInput(false)]
        public ActionResult TreeListDiaPhuongPartial()
        {
            var Model = db.DM_DiaPhuong.ToList();
            return PartialView("_TreeListDiaPhuongPartial", Model);
        }
    }
}