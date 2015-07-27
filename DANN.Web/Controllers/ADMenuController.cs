using DANN.Model;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DANN.Model.Common;
using DevExpress.Web.Mvc;
using DANN.Service;
namespace DANN.Web.Controllers
{

    public static class MenuCommon
    {
        public static DANNContext db = new DANNContext();
        public static IEnumerable<AD_Menu> GetList(int? parentID = null)
        {
            foreach (var item in db.AD_Menu
                .Where(x => x.ParentId == parentID)
               .OrderBy(x => x.MenuSort)
               .ToList())
            {
                yield return item;

                foreach (var child in GetList(item.Id))
                {
                    yield return child;
                }
            }
        }

        public static ASPxMenu BuildMenu(ASPxMenu menu)
        {
            List<AD_Menu> menus = GetList().ToList();

            for (int i = 0; i < menus.Count; i++)
            {
                AD_Menu row = menus[i];

                MenuItem item = new MenuItem();
                item.Name = row.Id + "";
                item.Text = row.MenuText;
                item.NavigateUrl = DevExpressHelper.GetUrl(new { Controller = row.MenuAction, Action = "Index" }); ;
                item.Image.Url = row.MenuIcon;
                item.BeginGroup = row.MenuSeparator.HasValue ? row.MenuSeparator.Value : false;

                if (i == 0 || row.ParentId + "" == "")
                {
                    menu.Items.Add(item);
                }
                else
                {
                    GetNodes(menu.Items, row.ParentId + "", item);
                }
            }

            return menu;
        }
        public static void GetNodes(MenuItemCollection menus, string parentID, MenuItem item)
        {
            if (menus == null)
            {
                return;
            }
            foreach (MenuItem myitem in menus)
            {
                if (myitem.Name == parentID)
                {
                    myitem.Items.Add(item);
                }
                GetNodes(myitem.Items, parentID, item);
            }
        }




    }

    public class ADMenuController : CommonController<AD_Menu>
    {
        public ADMenuController(IEntityService<AD_Menu> service)
            : base(service)
        {

        }

        //DANNContext db = new DANNContext();
        //public ActionResult Index()
        //{

        //    return View();
        //}

        //#region MENU
        //[ValidateInput(false)]
        //public ActionResult Menu()
        //{
        //    ViewBag.ListImages = Common.ListAllImage32();
        //    var model = GetListOrdered().ToList();
        //    return PartialView("_Menu", model);
        //}
        //public IEnumerable<AD_Menu> GetListOrdered(int? parentID = null)
        //{
        //    int i = 0;
        //    foreach (var item in db.AD_Menu
        //        .Where(x => x.ParentId == parentID)
        //       .OrderBy(x => x.MenuSort)
        //       .ToList())
        //    {
        //        item.MenuSort = i++;
        //        yield return item;
        //        int j = 0;
        //        foreach (var child in GetListOrdered(item.Id))
        //        {
        //            child.MenuSort = j++;
        //            yield return child;
        //        }
        //    }
        //}


        //[HttpPost, ValidateInput(false)]
        //public ActionResult MenuAddNew(AD_Menu item)
        //{
        //    var model = db.AD_Menu;
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
        //    return PartialView("_Menu", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult MenuUpdate(AD_Menu item)
        //{
        //    var model = db.AD_Menu;
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
        //    return PartialView("_Menu", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult MenuDelete(Int32 Id)
        //{
        //    var model = db.AD_Menu;
        //    if (Id != 0)
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
        //    return PartialView("_Menu", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult MenuMove(Int32 Id, Int32? ParentId)
        //{
        //    var model = db.AD_Menu;
        //    try
        //    {
        //        var item = model.FirstOrDefault(it => it.Id == Id);
        //        if (item != null)
        //            item.ParentId = ParentId;
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        ViewData["EditError"] = e.Message;
        //    }
        //    return PartialView("_Menu", model.ToList());
        //} 
        //#endregion

        #region Custom TreeList


        #endregion
    }

}