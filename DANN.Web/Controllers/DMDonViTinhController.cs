using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DMDonViTinhController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult DonViTinhGrid()
        {
            var model = db.DM_DonViTinh;
            return PartialView("_DonViTinhGrid", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DonViTinhGridAddNew(DANN.Model.DM_DonViTinh item)
        {
            var model = db.DM_DonViTinh;
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
            return PartialView("_DonViTinhGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DonViTinhGridUpdate(DANN.Model.DM_DonViTinh item)
        {
            var model = db.DM_DonViTinh;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
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
            return PartialView("_DonViTinhGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DonViTinhGridDelete(System.Int32 Id)
        {
            var model = db.DM_DonViTinh;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DonViTinhGrid", model.ToList());
        }
    }
}