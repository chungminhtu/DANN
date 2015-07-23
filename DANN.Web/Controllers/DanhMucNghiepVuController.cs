using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DanhMucNghiepVuController : Controller
    {
        //
        // GET: /DanhMucNghiepVu/
        public ActionResult Index()
        {
            return View();
        }

        DANN.Web.Models.BDVTW_DBEntities db = new DANN.Web.Models.BDVTW_DBEntities();

        [ValidateInput(false)]
        public ActionResult GridView3Partial()
        {
            var model = db.DMNghiepVus;
            return PartialView("_GridView3Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialAddNew(DANN.Web.Models.DMNghiepVu item)
        {
            var model = db.DMNghiepVus;
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
            return PartialView("_GridView3Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialUpdate(DANN.Web.Models.DMNghiepVu item)
        {
            var model = db.DMNghiepVus;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.MaNghiepVu == item.MaNghiepVu);
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
            return PartialView("_GridView3Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView3PartialDelete(System.Guid MaNghiepVu)
        {
            var model = db.DMNghiepVus;
            if (MaNghiepVu != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.MaNghiepVu == MaNghiepVu);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView3Partial", model.ToList());
        }
	}
}