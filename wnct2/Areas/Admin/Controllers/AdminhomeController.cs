using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wnct2.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminhomeController : Controller
    {
        // GET: Admin/Adminhome
        public ActionResult Index()
        {
            return View();
        }
    }
}