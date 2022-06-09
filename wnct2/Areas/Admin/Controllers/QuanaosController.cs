using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;

namespace wnct2.Areas.Admin.Controllers
{
    [Authorize]
    public class QuanaosController : Controller
    {
        private wnct1Entities db = new wnct1Entities();

        // GET: Admin/Quanaos
        public ActionResult Index()
        {
            return View(db.Quanao.ToList());
        }

        // GET: Admin/Quanaos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quanao quanao = db.Quanao.Find(id);
            if (quanao == null)
            {
                return HttpNotFound();
            }
            return View(quanao);
        }

        // GET: Admin/Quanaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Quanaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahh,Tenhh,DongGia,Producer,Hsd,Anh,Type,Mota")] Quanao quanao)
        {
            var f = Request.Files["Anh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/Asset/FileUpload/") + f.FileName;
                f.SaveAs(path);
                quanao.Anh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Quanao.Add(quanao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanao);
        }

        // GET: Admin/Quanaos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quanao quanao = db.Quanao.Find(id);
            if (quanao == null)
            {
                return HttpNotFound();
            }
            return View(quanao);
        }

        // POST: Admin/Quanaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahh,Tenhh,DongGia,Producer,Hsd,Anh,Type,Mota")] Quanao quanao)
        {
            var f = Request.Files["Anh"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/Areas/Asset/FileUpload/") + f.FileName;
                f.SaveAs(path);
                quanao.Anh = f.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(quanao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanao);
        }

        // GET: Admin/Quanaos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quanao quanao = db.Quanao.Find(id);
            if (quanao == null)
            {
                return HttpNotFound();
            }
            return View(quanao);
        }

        // POST: Admin/Quanaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Quanao quanao = db.Quanao.Find(id);
            db.Quanao.Remove(quanao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
