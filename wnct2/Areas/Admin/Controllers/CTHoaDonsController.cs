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
    public class CTHoaDonsController : Controller
    {
        private wnct1Entities db = new wnct1Entities();

        // GET: Admin/CTHoaDons
        public ActionResult Index()
        {
            var cTHoaDon = db.CTHoaDon.Include(c => c.HoaDon).Include(c => c.Quanao);
            return View(cTHoaDon.ToList());
        }

        // GET: Admin/CTHoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDon.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // GET: Admin/CTHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDon, "MaHD", "MaNV");
            ViewBag.Mahh = new SelectList(db.Quanao, "Mahh", "Tenhh");
            return View();
        }

        // POST: Admin/CTHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,Mahh,SoLuong")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CTHoaDon.Add(cTHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDon, "MaHD", "MaNV", cTHoaDon.MaHD);
            ViewBag.Mahh = new SelectList(db.Quanao, "Mahh", "Tenhh", cTHoaDon.Mahh);
            return View(cTHoaDon);
        }

        // GET: Admin/CTHoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDon.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDon, "MaHD", "MaNV", cTHoaDon.MaHD);
            ViewBag.Mahh = new SelectList(db.Quanao, "Mahh", "Tenhh", cTHoaDon.Mahh);
            return View(cTHoaDon);
        }

        // POST: Admin/CTHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,Mahh,SoLuong")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDon, "MaHD", "MaNV", cTHoaDon.MaHD);
            ViewBag.Mahh = new SelectList(db.Quanao, "Mahh", "Tenhh", cTHoaDon.Mahh);
            return View(cTHoaDon);
        }

        // GET: Admin/CTHoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDon.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // POST: Admin/CTHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHoaDon cTHoaDon = db.CTHoaDon.Find(id);
            db.CTHoaDon.Remove(cTHoaDon);
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
