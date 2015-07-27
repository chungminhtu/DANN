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
    public class CommonController<T> : Controller
        where T : BaseEntity
    {
        IEntityService<T> _service;

        public CommonController(IEntityService<T> service)
        {
            _service = service;
        }

        DANNContext db = new DANNContext();

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Load()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            var model = _service.GetAll().ToList();// GetListOrdered().ToList();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        public IEnumerable<AD_Menu> GetListOrdered(int? parentID = null)
        {
            int i = 0;
            foreach (var item in db.AD_Menu
                .Where(x => x.ParentId == parentID)
               .OrderBy(x => x.MenuSort)
               .ToList())
            {
                item.MenuSort = i++;
                yield return item;
                int j = 0;
                foreach (var child in GetListOrdered(item.Id))
                {
                    child.MenuSort = j++;
                    yield return child;
                }
            }
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew(T item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Create(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service.GetAll().ToList();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update(T item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service.GetAll().ToList();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete(Int32 Id)
        {
            if (Id != 0)
            {
                try
                {
                    _service.Delete(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = _service.GetAll().ToList();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move(Int32 Id, Int32? ParentId)
        {
            var model = _service.GetAll();
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
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
    }
}