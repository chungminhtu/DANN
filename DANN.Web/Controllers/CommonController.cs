using DANN.Model;
using DANN.Model.Common;
using DANN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
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

        public ActionResult Index()
        {
            return View();
        }

        #region T

        [ValidateInput(false)]
        public ActionResult Load()
        {
            ViewBag.ListImages = Common.ListAllImage32();

            PropertyInfo pInfo = typeof(T).GetProperties()[0];
            if (pInfo.PropertyType == typeof(int))
            {
                ViewBag.MaxId = _service.MaxId();
            } 
            var model = _service.GetAll();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew(T item)
        {
            return CommonAction(_service, "addnew", item);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update(T item)
        {
            return CommonAction(_service, "update", item); 
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete(T item)
        {


            return CommonAction(_service, "delete", item);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move(T item)
        {
            var model = _service.GetAll();
            try
            {
                _service.Move(item);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }

        private ActionResult CommonAction(IEntityService<T> s, string action, T item)
        {
            if (action == "delete")
            {
                try
                {
                    s.Delete(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (action == "addnew")
                        {
                            s.Create(item);
                        }
                        if (action == "update")
                        {
                            PropertyInfo pInfo = typeof(T).GetProperties()[0];
                            if (pInfo.PropertyType == typeof(int))
                            {
                                  s.Update(item);
                            }
                            else
                            {
                                s.Update(item);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = (from itemError in ModelState
                                             where itemError.Value.Errors.Any()
                                             select itemError.Value.Errors[0].ErrorMessage).FirstOrDefault();
            }
            var model = _service.GetAll();
            string viewName = typeof(T).Name.Split('_')[1];
            return PartialView(viewName, model);
        }


        #endregion

        #region T1

        [ValidateInput(false)]
        public ActionResult Load1()
        {
            //int s = Request.Params["ID"] + "" != "" ? Convert.ToInt32(Request.Params["ID"]) : 0;
            int ID = CommonFunctions.TryParseObjectToInt(Request.Params["ID"]);
            var model = _service1.SearchToList("CodeKind_Id = " + ID);
            ViewBag.MaxCodeValue = _service1.MaxCodeValue(ID);
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew1(T1 item)
        {
            return CommonAction1(_service1, "addnew", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update1(T1 item)
        {
            return CommonAction1(_service1, "update", item);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete1(T1 item)
        {
            return CommonAction1(_service1, "delete", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move1(T1 item)
        {
            var model = _service1.GetAll();
            try
            {
                _service1.Move(item);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }

        private ActionResult CommonAction1(IEntityService<T1> s, string action, T1 item)
        {
            int ID = CommonFunctions.TryParseObjectToInt(Request.Params["ID"]);
            if (action == "delete")
            {
                try
                {
                    s.Delete(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (action == "addnew")
                        {
                            s.CreateWithParentID(item, ID);
                        }
                        if (action == "update")
                        {
                            s.UpdateWithParentID(item, ID);
                        }
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = (from itemError in ModelState
                                             where itemError.Value.Errors.Any()
                                             select itemError.Value.Errors[0].ErrorMessage).FirstOrDefault();
            }
            var model = _service1.SearchToList(string.Format("{0} = {1}", typeof(T1).GetProperties()[1].Name, ID));
            string viewName = typeof(T1).Name.Split('_')[1];
            return PartialView(viewName, model);
        }


        #endregion

        #region T2

        [ValidateInput(false)]
        public ActionResult Load2()
        {
            ViewBag.ListImages = Common.ListAllImage32();
            var model = _service2.GetAll();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew2(T2 item)
        {
            return CommonAction2(_service2, "addnew", item);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Update2(T2 item)
        {
            return CommonAction2(_service2, "update", item);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Delete2(T2 item)
        {


            return CommonAction2(_service2, "delete", item);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Move2(T2 item)
        {
            var model = _service2.GetAll();
            try
            {
                _service2.Move(item);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }

        private ActionResult CommonAction2(IEntityService<T2> s, string action, T2 item)
        {
            if (action == "delete")
            {
                try
                {
                    s.Delete(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (action == "addnew")
                        {
                            s.Create(item);
                        }
                        if (action == "update")
                        {
                            s.Update(item);
                        }
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = (from itemError in ModelState
                                             where itemError.Value.Errors.Any()
                                             select itemError.Value.Errors[0].ErrorMessage).FirstOrDefault();
            }
            var model = _service2.GetAll();
            string viewName = typeof(T2).Name.Split('_')[1];
            return PartialView(viewName, model);
        }


        #endregion


    }
}