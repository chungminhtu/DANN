using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class ADLichSuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult LichSuGrid()
        {
            var model = db.AD_LichSu;
            return PartialView("_LichSuGrid", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LichSuGridAddNew(DANN.Model.AD_LichSu item)
        {
            var model = db.AD_LichSu;
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
            return PartialView("_LichSuGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult LichSuGridUpdate(DANN.Model.AD_LichSu item)
        {
            var model = db.AD_LichSu;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.LichSu_Id == item.LichSu_Id);
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
            return PartialView("_LichSuGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult LichSuGridDelete(System.Int32 LichSu_Id)
        {
            var model = db.AD_LichSu;
            if (LichSu_Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.LichSu_Id == LichSu_Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_LichSuGrid", model.ToList());
        }
    }
}