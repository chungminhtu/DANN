using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class TKChiTieuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult ChiTieuTree()
        {
            var model = db.TK_ChiTieu;
            return PartialView("_ChiTieuTree", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTieuTreeAddNew(DANN.Model.TK_ChiTieu item)
        {
            var model = db.TK_ChiTieu;
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
            return PartialView("_ChiTieuTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTieuTreeUpdate(DANN.Model.TK_ChiTieu item)
        {
            var model = db.TK_ChiTieu;
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
            return PartialView("_ChiTieuTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTieuTreeDelete(Int32 Id)
        {
            var model = db.TK_ChiTieu;
            if (Id != 0)
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
            return PartialView("_ChiTieuTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTieuTreeMove(Int32 Id, Int32? ParentId)
        {
            var model = db.TK_ChiTieu;
            try
            {
                var item = model.FirstOrDefault(it => it.Id == Id);
                if (item != null)
                    item.ParentId = ParentId;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_ChiTieuTree", model.ToList());
        }
    }
}