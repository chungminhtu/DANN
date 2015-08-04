using DANN.Model;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DANN.Model.Common;
using DevExpress.Web.Mvc;
using DANN.Service;
using System.Reflection;

namespace DANN.Web.Controllers
{


    public  class MenuCommon
    {
        public DANNContext db { get; set; }
        public MenuCommon()
        {
            db = new DANNContext();
        } 

        public  IEnumerable<AD_Menu> GetList(int? parentID = null)
        {
            var temp = db.AD_Menu
                       .Where(x => x.Menu_ParentId == parentID)
                       .OrderBy(x => x.MenuSort)
                       .ToList();
            foreach (var item in temp)
            {
                yield return item;

                foreach (var child in GetList(item.Menu_Id))
                {
                    yield return child;
                }
            }
        }

        public  ASPxMenu BuildMenu(ASPxMenu menu)
        {
            List<AD_Menu> menus = GetList().ToList();

            for (int i = 0; i < menus.Count; i++)
            {
                AD_Menu row = menus[i];

                MenuItem item = new MenuItem();
                item.Name = row.Menu_Id + "";
                item.Text = row.MenuText;
                item.NavigateUrl = DevExpressHelper.GetUrl(new { Controller = row.MenuAction, Action = "Index" }); ;
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
        public  void GetNodes(MenuItemCollection menus, string parentID, MenuItem item)
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


    public class ADMenuController : CommonController<AD_Menu, AD_Menu, AD_Menu>
    {
        IEntityService<AD_Menu> _service; 
        IEntityService<DM_PhanHe> _phanheService;
        public ADMenuController(IEntityService<AD_Menu> service, IEntityService<AD_Menu> service1, IEntityService<AD_Menu> service2, IEntityService<DM_PhanHe> phanheService)
            : base(service, service1, service2)
        {
            _service = service;
            _phanheService = phanheService;
        }

        [ValidateInput(false)]
        public ActionResult LoadMenu()
        {
            ViewBag.ListPhanHe = _phanheService.GetAll();
            ViewBag.ListImages = Common.ListAllImage32();
            var model = _service.GetAll(); 
            return PartialView("Menu", model);
        }

        [HttpPost, ValidateInput(false)]
        public void SetPhanHeToListMenuIDs()
        {
            string selectedMenuIDs = Request.Params["selectedIDs"] + "";
            string TenPhanHeParam = Request.Params["TenPhanHeParam"] + "";
            if (selectedMenuIDs != "")
            { 
                List<string> ListMenuIDs = selectedMenuIDs.Split(',').ToList();
                foreach (var menuId in ListMenuIDs)
                {
                    var entity = (_service.GetEntityById(menuId));
                    entity.PhanHe = TenPhanHeParam;
                    _service.Update(entity);
                }
            }
        }
    }

}