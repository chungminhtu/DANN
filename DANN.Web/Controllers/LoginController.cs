using DANN.Service;
using DANN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTP_MVC.Controllers
{
    public class LoginController : Controller
    {
        DANNContext db = new DANNContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AD_User user)
        {
            var User = db.AD_User.Where(u => u.UserName.Equals(user.UserName)).Where(u => u.Password.Equals(user.Password)).SingleOrDefault();

            if (User != null)
            {
                Session["UserId"] = User.User_Id;
                return RedirectToAction("Index", "ADUser");
            }
            else
            {
                ViewData["EditError"] = "Tên đăng nhập hoặc mật khẩu không đúng! Hãy thử lại.";
                return View("Index");
            }
        }

    }
}