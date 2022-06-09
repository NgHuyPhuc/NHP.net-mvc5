using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;
namespace wnct2.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pa_Item()
        {
            var lst = new List<Quanao>();

            wnct1Entities db = new wnct1Entities();
            lst=db.Quanao.Where(x=>x.Type=="moi").Take(5).ToList();
            return PartialView(lst);
        }
        public ActionResult Pa_Itemsale()
        {
            var lst = new List<Quanao>();

            wnct1Entities db = new wnct1Entities();
            lst = db.Quanao.Where(x => x.Type == "random sale").Take(5).ToList();
            return PartialView(lst);
        }
        public ActionResult Pa_Itemwibu()
        {
            var lst = new List<Quanao>();

            wnct1Entities db = new wnct1Entities();
            lst = db.Quanao.Where(x => x.Type == "wibu").Take(3).ToList();
            return PartialView(lst);
        }
        public ActionResult Pa_Itemgame()
        {
            var lst = new List<Quanao>();

            wnct1Entities db = new wnct1Entities();
            lst = db.Quanao.Where(x => x.Type == "game").Take(8).ToList();
            return PartialView(lst);
        }
    }
}