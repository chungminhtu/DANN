using DANN.Model;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DANN.Model.Common;

namespace DANN.Web.Controllers
{

    public static class MyClass
    {
        public static IEnumerable<AD_Menu> GetList(int? parentID = null)
        {
            DANNContext db = new DANNContext();

            foreach (var item in db.AD_Menu
                .Where(x => x.Menu_ParentId == parentID)
               .OrderBy(x => x.MenuSort)
               .ToList())
            {

                yield return item;

                foreach (var child in GetList(item.Menu_Id))
                {
                    yield return child;
                }
            }
        }

        public static ASPxMenu BuildMenu(ASPxMenu menu)
        {
            DANNContext db = new DANNContext();

            List<AD_Menu> menus = GetList().ToList();

            for (int i = 0; i < menus.Count; i++)
            {
                AD_Menu row = menus[i];

                MenuItem item = new MenuItem();
                item.Name = row.Menu_Id + "";
                item.Text = row.MenuText;
                item.NavigateUrl = row.MenuAction;
                item.Image.Url = row.MenuIcon;
                item.BeginGroup = row.MenuSeparator.HasValue ? row.MenuSeparator.Value : false;
                 
                if (i == 0 || row.Menu_ParentId + "" == "")
                {
                    menu.Items.Add(item);
                }
                else
                {
                    GetNodes(menu.Items, row.Menu_ParentId + "", item);
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

    public class MenuController : Controller
    {
        DANNContext db = new DANNContext();
        public ActionResult Index()
        {

            return View();
        }

        #region MENU
        [ValidateInput(false)]
        public ActionResult Menu()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            var model = db.AD_Menu;
            return PartialView("_Menu", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MenuAddNew(AD_Menu item)
        {
            var model = db.AD_Menu;
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
            return PartialView("_Menu", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuUpdate(AD_Menu item)
        {
            var model = db.AD_Menu;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Menu_Id == item.Menu_Id);
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
            return PartialView("_Menu", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuDelete(Int32 Menu_Id)
        {
            var model = db.AD_Menu;
            if (Menu_Id != 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Menu_Id == Menu_Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_Menu", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuMove(Int32 Menu_Id, Int32? Menu_ParentId)
        {
            var model = db.AD_Menu;
            try
            {
                var item = model.FirstOrDefault(it => it.Menu_Id == Menu_Id);
                if (item != null)
                    item.Menu_ParentId = Menu_ParentId;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_Menu", model.ToList());
        }


        #endregion

        #region Custom TreeList


        #endregion
    }

}