using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DanhMucDonViTinhController : Controller
    {
        //
        // GET: /DanhMucDonViTinh/
        public ActionResult Index()
        {
            return View();
        }

        DANN.Web.Models.BDVTW_DBEntities db = new DANN.Web.Models.BDVTW_DBEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.DonViTinhs;
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(DANN.Web.Models.DonViTinh item)
        {
            var model = db.DonViTinhs;
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
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(DANN.Web.Models.DonViTinh item)
        {
            var model = db.DonViTinhs;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.MaDonViTinh == item.MaDonViTinh);
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
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 MaDonViTinh)
        {
            var model = db.DonViTinhs;
            if (MaDonViTinh >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.MaDonViTinh == MaDonViTinh);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
	}
}