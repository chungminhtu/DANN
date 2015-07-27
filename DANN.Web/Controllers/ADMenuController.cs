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


    public class ADMenuController : CommonController<AD_Menu, AD_Menu, AD_Menu>
    {
        IEntityService<AD_Menu> _service;
        IAD_MenuService _menuService;
        public ADMenuController(IEntityService<AD_Menu> service, IEntityService<AD_Menu> service1, IEntityService<AD_Menu> service2, IAD_MenuService menuService)
            : base(service, service1, service2)
        {
            _service = service;
            _menuService = menuService;
        }
    }

}