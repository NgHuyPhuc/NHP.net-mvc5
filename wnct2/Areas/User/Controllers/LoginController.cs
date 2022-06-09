using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace wnct2.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        // GET: User/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.DTO.UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool isVal = Models.DAO.AccountDAO.checkLogin(user.TaiKhoan,user.MatKhau);
                if (isVal == true)
                {
                    string ReturnUrl = "";
                    Session["UserName"] = user.TaiKhoan;
                    FormsAuthentication.SetAuthCookie(user.MatKhau, false);
                    if (Request.QueryString["ReturnUrl"] == null)
                        ReturnUrl = "~/User/Home/Index";

                    else ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                    return Redirect(ReturnUrl);
                }
                
            }
            return View(user);

        }

        public ActionResult Logout()
        {
            // Hủy session đã lưu dưới Client
            Session.Remove("id");
            Session.Remove("userName");
            return Redirect("~/User/Home/Index");
        }
        public ActionResult account()
        {

            return PartialView();
        }

    }
}