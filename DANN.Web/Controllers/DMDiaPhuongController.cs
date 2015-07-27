using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DMDiaPhuongController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult DiaPhuongTree()
        {
            var model = db.DM_DiaPhuong;
            return PartialView("_DiaPhuongTree", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DiaPhuongTreeAddNew(DANN.Model.DM_DiaPhuong item)
        {
            var model = db.DM_DiaPhuong;
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
            return PartialView("_DiaPhuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DiaPhuongTreeUpdate(DANN.Model.DM_DiaPhuong item)
        {
            var model = db.DM_DiaPhuong;
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
            return PartialView("_DiaPhuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DiaPhuongTreeDelete(Int32 Id)
        {
            var model = db.DM_DiaPhuong;
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
            return PartialView("_DiaPhuongTree", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DiaPhuongTreeMove(Int32 Id, Int32? ParentId)
        {
            var model = db.DM_DiaPhuong;
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
            return PartialView("_DiaPhuongTree", model.ToList());
        }
    }
}