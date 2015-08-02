﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Model;
using DANN.Service;
using DANN.Model.Common;

namespace DANN.Web.Controllers
{
    public class ADUserController : CommonController<AD_User, AD_User_Menu, AD_Menu>
    {
        IEntityService<AD_User> _serviceUser { get; set; }
        IEntityService<AD_Menu> _serviceMenu { get; set; }
        IEntityService<AD_User_Menu> _serviceUserMenu { get; set; }

        public ADUserController(IEntityService<AD_User> service, IEntityService<AD_User_Menu> service1, IEntityService<AD_Menu> service2)
            : base(service, service1, service2)
        {
            _serviceUser = service;
            _serviceUserMenu = service1;
            _serviceMenu = service2;
        }

        [ValidateInput(false)]
        public ActionResult LoadPhanQuyen()
        {
            string UserID = Request.Params["UserID"] + "";
            //string selectedMenuIDs = Request.Params["selectedIDs"] + "";
            //if (selectedMenuIDs != "" && UserID != "" && Request.IsAjaxRequest())
            //{
            //    bool tatCaQuyen = Convert.ToBoolean(Request.Params["tatCaQuyen"]);
            //    bool quyenXem = Convert.ToBoolean(Request.Params["quyenXem"]);
            //    bool quyenThem = Convert.ToBoolean(Request.Params["quyenThem"]);
            //    bool quyenSua = Convert.ToBoolean(Request.Params["quyenSua"]);
            //    bool quyenXoa = Convert.ToBoolean(Request.Params["quyenXoa"]);
            //    bool quyenLuu = Convert.ToBoolean(Request.Params["quyenLuu"]);
            //    bool quyenIn = Convert.ToBoolean(Request.Params["quyenIn"]);
            //    List<string> ListMenuIDs = selectedMenuIDs.Split(',').ToList();
            //    foreach (var menuId in ListMenuIDs)
            //    {
            //        AD_User_Menu aum = new AD_User_Menu()
            //        {
            //            User_Id = UserID,
            //            Menu_Id = Convert.ToInt32(menuId), 
            //            TatCaQuyen = tatCaQuyen,
            //            QuyenXem = quyenXem,
            //            QuyenThem = quyenThem,
            //            QuyenSua = quyenSua,
            //            QuyenXoa = quyenXoa,
            //            QuyenLuu = quyenLuu,
            //            QuyenIn = quyenIn
            //        };
            //        _serviceUserMenu.InsertOrUpdate2Key(aum);
            //    }
            //}
            List<Quyen> model = new List<Quyen>();
            List<AD_Menu> ListMenus = _serviceMenu.GetAll();
            List<AD_User_Menu> ListUserMenu = _serviceUserMenu.GetListById(UserID);

            foreach (var item in ListMenus)
            {
                Quyen quyen = new Quyen()
                {
                    User_Id = UserID,
                    Menu_Id = item.Menu_Id,
                    Menu_ParentId = item.Menu_ParentId,
                    MenuText = item.MenuText,
                    MenuSort = item.MenuSort,
                    TatCaQuyen = false,
                    QuyenXem = false,
                    QuyenThem = false,
                    QuyenSua = false,
                    QuyenXoa = false,
                    QuyenLuu = false,
                    QuyenIn = false
                };
                foreach (var temp in ListUserMenu)
                {
                    if (item.Menu_Id == temp.Menu_Id)
                    {
                        quyen.TatCaQuyen = temp.TatCaQuyen;
                        quyen.QuyenXem = temp.QuyenXem;
                        quyen.QuyenThem = temp.QuyenThem;
                        quyen.QuyenSua = temp.QuyenSua;
                        quyen.QuyenXoa = temp.QuyenXoa;
                        quyen.QuyenLuu = temp.QuyenLuu;
                        quyen.QuyenIn = temp.QuyenIn;
                        ListUserMenu.Remove(temp);
                        break;
                    }
                }
                model.Add(quyen);
            }
            return PartialView("_PhanQuyen", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdatePhanQuyen(Quyen model)
        {
            string UserID = Request.Params["UserID"] + "";
            if (UserID != "")
            {
                AD_User_Menu um = new AD_User_Menu();
                um.User_Id = UserID;
                um.Menu_Id = model.Menu_Id;
                um.TatCaQuyen = model.TatCaQuyen;
                if (model.TatCaQuyen == true)
                {
                    um.QuyenXem = true;
                    um.QuyenThem = true;
                    um.QuyenSua = true;
                    um.QuyenXoa = true;
                    um.QuyenLuu = true;
                    um.QuyenIn = true;
                }
                else
                {
                    um.QuyenXem = model.QuyenXem;
                    um.QuyenThem = model.QuyenThem;
                    um.QuyenSua = model.QuyenSua;
                    um.QuyenXoa = model.QuyenXoa;
                    um.QuyenLuu = model.QuyenLuu;
                    um.QuyenIn = model.QuyenIn;
                }
                _serviceUserMenu.InsertOrUpdate2Key(um);
            }
            return LoadPhanQuyen();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdatePhanQuyenByListMenuIDs()
        {
            string selectedMenuIDs = Request.Params["selectedIDs"] + "";
            string UserID = Request.Params["UserID"] + "";
            if (selectedMenuIDs != "" && UserID != "" && Request.IsAjaxRequest())
            {
                bool tatCaQuyen = Convert.ToBoolean(Request.Params["tatCaQuyen"]);
                bool quyenXem = Convert.ToBoolean(Request.Params["quyenXem"]);
                bool quyenThem = Convert.ToBoolean(Request.Params["quyenThem"]);
                bool quyenSua = Convert.ToBoolean(Request.Params["quyenSua"]);
                bool quyenXoa = Convert.ToBoolean(Request.Params["quyenXoa"]);
                bool quyenLuu = Convert.ToBoolean(Request.Params["quyenLuu"]);
                bool quyenIn = Convert.ToBoolean(Request.Params["quyenIn"]);
                List<string> ListMenuIDs = selectedMenuIDs.Split(',').ToList();
                foreach (var menuId in ListMenuIDs)
                {
                    AD_User_Menu aum = new AD_User_Menu()
                    {
                        User_Id = UserID,
                        Menu_Id = Convert.ToInt32(menuId),
                        TatCaQuyen = tatCaQuyen,
                        QuyenXem = quyenXem,
                        QuyenThem = quyenThem,
                        QuyenSua = quyenSua,
                        QuyenXoa = quyenXoa,
                        QuyenLuu = quyenLuu,
                        QuyenIn = quyenIn
                    };
                    _serviceUserMenu.InsertOrUpdate2Key(aum);
                }
            }
            return LoadPhanQuyen();
        }


    }
}