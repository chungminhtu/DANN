using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Model;
using DANN.Service;

namespace DANN.Web.Controllers
{


    public class ADLichSuController : CommonController<AD_LichSu, AD_LichSu, AD_LichSu>
    {
        IEntityService<AD_LichSu> _service;

        public ADLichSuController(IEntityService<AD_LichSu> service, IEntityService<AD_LichSu> service1, IEntityService<AD_LichSu> service2)
            : base(service, service1, service2)
        {
            _service = service;
        }

        //DANNContext db = new DANNContext();

        //[ValidateInput(false)]
        //public ActionResult LichSuGrid()
        //{
        //    var model = db.AD_LichSu;
        //    return PartialView("_LichSuGrid", model.ToList());
        //}

        //[HttpPost, ValidateInput(false)]
        //public ActionResult LichSuGridAddNew(AD_LichSu item)
        //{
        //    var model = db.AD_LichSu;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.Add(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_LichSuGrid", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult LichSuGridUpdate(AD_LichSu item)
        //{
        //    var model = db.AD_LichSu;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
        //            if (modelItem != null)
        //            {
        //                this.UpdateModel(modelItem);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_LichSuGrid", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult LichSuGridDelete(System.Int32 Id)
        //{
        //    var model = db.AD_LichSu;
        //    if (Id >= 0)
        //    {
        //        try
        //        {
        //            var item = model.FirstOrDefault(it => it.Id == Id);
        //            if (item != null)
        //                model.Remove(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_LichSuGrid", model.ToList());
        //}
    }
}