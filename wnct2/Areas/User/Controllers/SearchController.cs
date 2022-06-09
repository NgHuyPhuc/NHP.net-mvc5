using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;
namespace wnct2.Areas.User.Controllers
{
    public class SearchController : Controller
    {
        private wnct1Entities db = new wnct1Entities();       
        [HttpPost]
        // GET: User/Search
        public ActionResult Search()
        {
            var lst = new List<Quanao>();
            string query = Request["search"];
            lst = db.Quanao.Where(x => x.Tenhh.Contains(query)).Take(15).ToList();
            return View(lst);
        }
    }
}