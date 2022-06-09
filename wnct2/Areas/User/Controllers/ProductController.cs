using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;

namespace wnct2.Areas.User.Controllers
{
    public class ProductController : Controller
    {
        // GET: User/Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pa_Itemsp()
        {
            var lst = new List<Quanao>();

            wnct1Entities db = new wnct1Entities();
            lst = db.Quanao.Where(x => x.Type == "sanpham").Take(15).ToList();
            return PartialView(lst);
        }
    }
}