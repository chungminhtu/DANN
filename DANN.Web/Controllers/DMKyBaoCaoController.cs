using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class DMKyBaoCaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        DANN.Model.DANNContext db = new DANN.Model.DANNContext();

        [ValidateInput(false)]
        public ActionResult KyBaoCaoGrid()
        {
            var model = db.DM_KyBaoCao;
            return PartialView("_KyBaoCaoGrid", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult KyBaoCaoGridAddNew(DANN.Model.DM_KyBaoCao item)
        {
            var model = db.DM_KyBaoCao;
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
            return PartialView("_KyBaoCaoGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult KyBaoCaoGridUpdate(DANN.Model.DM_KyBaoCao item)
        {
            var model = db.DM_KyBaoCao;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.KyBaoCao_Id == item.KyBaoCao_Id);
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
            return PartialView("_KyBaoCaoGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult KyBaoCaoGridDelete(System.Int32 KyBaoCao_Id)
        {
            var model = db.DM_KyBaoCao;
            if (KyBaoCao_Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.KyBaoCao_Id == KyBaoCao_Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_KyBaoCaoGrid", model.ToList());
        }
    }
}