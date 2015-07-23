using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DanhMucNhomChiTieuController : Controller
    {
        //
        // GET: /DanhMucNhomChiTieu/
        public ActionResult Index()
        {
            return View();
        }

        DANN.Web.Models.BDVTW_DBEntities db = new DANN.Web.Models.BDVTW_DBEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.DanhMucNhomChiTieux;
          

            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(DANN.Web.Models.DanhMucNhomChiTieu item)
        {
            var model = db.DanhMucNhomChiTieux;
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
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(DANN.Web.Models.DanhMucNhomChiTieu item)
        {
            var model = db.DanhMucNhomChiTieux;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.MaNhomChiTieu == item.MaNhomChiTieu);
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
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Guid MaNhomChiTieu)
        {
            var model = db.DanhMucNhomChiTieux;
            if (MaNhomChiTieu != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.MaNhomChiTieu == MaNhomChiTieu);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
	}
}