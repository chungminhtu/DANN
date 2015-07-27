using DANN.Model;
using DANN.Model.Common;
using DANN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DANN.Web.Controllers
{
    public class CommonController : Controller
    {

        IEntityService<AD_Menu> _MenuService;

        public CommonController(IEntityService<AD_Menu> MenuService)
        {
            _MenuService = MenuService;
        }


        DANNContext db = new DANNContext();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Menu()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            var model = _MenuService.GetAll().ToList();// GetListOrdered().ToList();
            return PartialView(model);
        }
        public IEnumerable<AD_Menu> GetListOrdered(int? parentID = null)
        {
            int i = 0;
            foreach (var item in db.AD_Menu
                .Where(x => x.Menu_ParentId == parentID)
               .OrderBy(x => x.MenuSort)
               .ToList())
            {
                item.MenuSort = i++;
                yield return item;
                int j = 0;
                foreach (var child in GetListOrdered(item.Menu_Id))
                {
                    child.MenuSort = j++;
                    yield return child;
                }
            }
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult MenuAddNew(AD_Menu item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _MenuService.Create(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_Menu", _MenuService.GetAll().ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuUpdate(AD_Menu item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _MenuService.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_Menu", _MenuService.GetAll().ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuDelete(Int32 Menu_Id)
        {
            if (Menu_Id != 0)
            {
                try
                {
                    _MenuService.Delete(_MenuService.FindBy(a => a.Menu_Id == Menu_Id).SingleOrDefault());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_Menu", _MenuService.GetAll().ToList());
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

    }
}