using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;
namespace wnct2.Areas.User.Controllers
{
    public class detailController : Controller
    {
        // GET: User/detail
        public ActionResult Index(String mahh)
        {
            wnct1Entities db = new wnct1Entities();
            List<Quanao> qa=db.Quanao.Where(x=>x.Mahh == mahh).ToList();

            return View(qa);

        }

        
    }
}