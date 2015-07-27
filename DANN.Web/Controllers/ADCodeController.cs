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
    public class ADCodeController : CommonController<DM_CodeKind, DM_Code, DM_Code>
    {

        public ADCodeController(IEntityService<DM_CodeKind> service, IEntityService<DM_Code> service1, IEntityService<DM_Code> service2)
            : base(service, service1, service2)
        {

        }



        //[ValidateInput(false)]
        //public ActionResult LoadCodeKind()
        //{
        //    var model = db.DM_CodeKind;
        //    ViewBag.MaxCodeKind = db.DM_CodeKind.Count() > 0 ? db.DM_CodeKind.Max(a => a.Id) : 0;
        //    return PartialView("_CodeKind", model.ToList());
        //}

        //[ValidateInput(false)]
        //public ActionResult LoadCode()
        //{
        //    var s = Request.Params["ID"] + "";
        //    List<DM_Code> model = null;
        //    if (s != "")
        //    {
        //        model = db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).ToList();
        //    }
        //    ViewBag.MaxCodeValue = db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).Count() > 0 ? db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).Max(a => a.CodeValue) : 0;
        //    return PartialView("_Code", model);
        //}

        //#region CodeKind GridView
        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeKindGridAddNew(DM_CodeKind item)
        //{
        //    var model = db.DM_CodeKind;
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
        //    return PartialView("_CodeKindGrid", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeKindGridUpdate(DM_CodeKind item)
        //{
        //    var model = db.DM_CodeKind;
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
        //    return PartialView("_CodeKindGrid", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeKindGridDelete(System.Int32 Id)
        //{
        //    var model = db.DM_CodeKind;
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
        //    return PartialView("_CodeKindGrid", model.ToList());
        //}
        //#endregion


        //#region Code GridView
        //[ValidateInput(false)]
        //public ActionResult CodeGrid()
        //{
        //    var s = Request.Params["ID"] + "";
        //    List<DM_Code> model = null;
        //    if (s != "")
        //    {
        //        model = db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).ToList();
        //    }
        //    ViewBag.MaxCodeValue = db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).Count() > 0 ? db.DM_Code.Where(x => x.CodeKind_Id.ToString().Contains(s)).Max(a => a.CodeValue) : 0;
        //    return PartialView("_CodeGrid", model);
        //}

        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeGridAddNew(DM_Code item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            item.CodeKind_Id = Convert.ToInt32(Request.Params["ID"]);
        //            db.DM_Code.Add(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    var model = db.DM_Code.Where(x => x.Id == item.Id).ToList();
        //    return PartialView("_CodeGrid", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeGridUpdate(DM_Code item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var modelItem = db.DM_Code.FirstOrDefault(it => it.Id == item.Id);
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
        //    int s = Convert.ToInt32(Request.Params["ID"]);
        //    var model = db.DM_Code.Where(x => x.Id == s).ToList();
        //    return PartialView("_CodeGrid", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult CodeGridDelete(System.Int32 Code)
        //{
        //    if (Code >= 0)
        //    {
        //        try
        //        {
        //            var item = db.DM_Code.FirstOrDefault(it => it.Id == Code);
        //            if (item != null)
        //                db.DM_Code.Remove(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    var model = db.DM_Code.Where(x => x.Id == Code).ToList();
        //    return PartialView("_CodeGrid", model);
        //}
        //#endregion
    }
}