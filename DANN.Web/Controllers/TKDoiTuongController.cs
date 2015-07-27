using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class TKDoiTuongController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult DoiTuongTree()
        {
            var model = db.TK_DoiTuong;
            return PartialView("_DoiTuongTree", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DoiTuongTreeAddNew(DANN.Model.TK_DoiTuong item)
        {
            var model = db.TK_DoiTuong;
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
            return PartialView("_DoiTuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DoiTuongTreeUpdate(DANN.Model.TK_DoiTuong item)
        {
            var model = db.TK_DoiTuong;
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
            return PartialView("_DoiTuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DoiTuongTreeDelete(Int32 Id)
        {
            var model = db.TK_DoiTuong;
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
            return PartialView("_DoiTuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DoiTuongTreeMove(Int32 Id, Int32? ParentId)
        {
            var model = db.TK_DoiTuong;
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
            return PartialView("_DoiTuongTree", model.ToList());
        }
    }
}