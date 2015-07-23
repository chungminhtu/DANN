using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class ChiTieuNghiepVuController : Controller
    {
        //
        // GET: /ChiTieuNghiepVu/
        public ActionResult Index()
        {
            return View();
        }

        DANN.Web.Models.BDVTW_DBEntities db = new DANN.Web.Models.BDVTW_DBEntities();

        [ValidateInput(false)]
        public ActionResult TreeListPartial()
        {
            var model = db.NghiepVuChiTieux;
            return PartialView("_TreeListPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialAddNew(DANN.Web.Models.NghiepVuChiTieu item)
        {
            var model = db.NghiepVuChiTieux;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TreeListPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialUpdate(DANN.Web.Models.NghiepVuChiTieu item)
        {
            var model = db.NghiepVuChiTieux;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.MaChiTieu == item.MaChiTieu);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TreeListPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialDelete(System.Guid? MaChiTieu)
        {
            var model = db.NghiepVuChiTieux;
            if (MaChiTieu != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.MaChiTieu == MaChiTieu);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TreeListPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialMove(System.Guid? MaChiTieu, System.Guid? MaChiTieuCha)
        {
            var model = db.NghiepVuChiTieux;
            try
            {
                var item = model.FirstOrDefault(it => it.MaChiTieu == MaChiTieu);
                if (item != null)
                    item.MaChiTieuCha = MaChiTieuCha;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_TreeListPartial", model.ToList());
        }
	}
}