using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace wnct2.Areas.Admin.Controllers
{
    public class LoginadminController : Controller
    {
        // GET: Admin/Loginadmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.DTO.User user)
        {
            if (ModelState.IsValid)
            {
                wnct2.Models.Framework.wnct1Entities db = new wnct2.Models.Framework.wnct1Entities();
                var _user = db.NguoiDung.FirstOrDefault(x => x.TaiKhoan == user.TaiKhoan && x.MatKhau == user.MatKhau && x.accRole == "admin");
                if(_user!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.TaiKhoan, false);
                    return RedirectToAction("Index", "Adminhome");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                }
                //bool isVal = Models.DAO.AccountDAO.checkLogin(user.TaiKhoan, user.MatKhau);
                //if (isVal == true)
                //{
                //    string ReturnUrl = "";
                //    Session["UserName"] = user.TaiKhoan;
                //    FormsAuthentication.SetAuthCookie(user.MatKhau, false);
                //    if (Request.QueryString["ReturnUrl"] == null)
                //        ReturnUrl = "~/User/Home/Index/";

                //    else ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                //    return Redirect(ReturnUrl);
                //}

            }
            return View(user);

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}