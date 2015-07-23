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
        public static ASPxMenu BuildMenu(ASPxMenu menu)
        {
            DANNContext db = new DANNContext();
            //DevSampleEntities db = new DevSampleEntities();
            List<AD_Menu> items = db.AD_Menu.OrderBy(m => m.Menu_Id).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                AD_Menu row = items[i];
                MenuItem item = CreateMenuItem(row);
                string itemID = row.Menu_Id + "";
                string parentID = row.Menu_ParentId + "";

                menu.Items.Add(item);

            }

            for (int j = 0; j < items.Count; j++)
            {
                AD_Menu row = items[j];
                MenuItem item = CreateMenuItem(row);
                string itemID = row.Menu_Id + "";
                string parentID = row.Menu_ParentId + "";


                if (menu.Items[j].Name == itemID)
                {
                    menu.Items[j].Items.Add(item);
                }
            }
            return menu;
        }

        static MenuItem CreateMenuItem(AD_Menu row)
        {
            MenuItem ret = new MenuItem();
            ret.DataItem = row.Menu_Id;
            ret.Name = row.Menu_ParentId + "";
            ret.Text = row.MenuText;
            ret.NavigateUrl = row.MenuAction;
            ret.Image.Url = row.MenuIcon;
            return ret;
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
    }

}