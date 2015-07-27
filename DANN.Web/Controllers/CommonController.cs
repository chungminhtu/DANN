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
    public class CommonController<T, T1, T2> : Controller
        where T : BaseEntity
        where T1 : BaseEntity
        where T2 : BaseEntity
    {
        IEntityService<T> _service;
        IEntityService<T1> _service1;
        IEntityService<T2> _service2;

        public CommonController(IEntityService<T> service, IEntityService<T1> service1, IEntityService<T2> service2)
        {
            _service = service;
            _service1 = service1;
            _service2 = service2;
        }

        DANNContext db = new DANNContext();

        public ActionResult Index()
        {
            return View();
        }

        #region T

        [ValidateInput(false)]
        public ActionResult Load()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            ViewBag.MaxId = _service.GetAll().Count() > 0 ? _service.GetAll().Max(a => a.Id) : 0;
            var model = _service.GetAll().ToList();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
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
        #endregion

        #region T1

        [ValidateInput(false)]
        public ActionResult Load1()
        {
            int s = Request.Params["ID"] + "" != "" ? Convert.ToInt32(Request.Params["ID"]) : 0;
            var model = _service1.GetListCodeByCodeKindId(s);
            ViewBag.MaxId1 = _service1.GetAll().Where(x => x.Id == s).Count() > 0 ? _service1.GetAll().Where(x => x.Id == s).Max(a => a.Id) : 0;
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew1(T1 item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service1.Create(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service1.GetAll().ToList();
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update1(T1 item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service1.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service1.GetAll().ToList();
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete1(Int32 Id)
        {
            if (Id != 0)
            {
                try
                {
                    _service1.Delete(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = _service1.GetAll().ToList();
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move1(Int32 Id, Int32? ParentId)
        {
            var model = _service1.GetAll();
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
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        #endregion

        #region T2

        [ValidateInput(false)]
        public ActionResult Load2()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            var model = _service2.GetAll().ToList();// GetListOrdered().ToList();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew2(T2 item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service2.Create(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service2.GetAll().ToList();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update2(T2 item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service2.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = _service2.GetAll().ToList();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete2(Int32 Id)
        {
            if (Id != 0)
            {
                try
                {
                    _service2.Delete(Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = _service2.GetAll().ToList();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move2(Int32 Id, Int32? ParentId)
        {
            var model = _service2.GetAll();
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
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        #endregion
    }
}