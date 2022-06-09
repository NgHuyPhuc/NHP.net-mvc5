using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wnct2.Models.Framework;

namespace wnct2.Areas.User.Controllers
{
    public class CartController : Controller
    {
        wnct1Entities db = new wnct1Entities();
        // GET: User/Cart
        public ActionResult Index()
        {
            List<itemcart> lst = getcart();
            Session["soluong"] = tinhsoluong();
            ViewBag.qty = tinhsoluong();
            ViewBag.tt = tinhtongtien();
            return View(lst);
        }
        public double tinhsoluong()
        {
            List<itemcart> lst = Session["Cart"] as List<itemcart>;
            if(lst==null)
            {
                return 0;
            }
            return lst.Sum(x => x.soluong);
        }
        public int tinhtongtien()
        {
            List<itemcart> lst = Session["Cart"] as List<itemcart>;
            if(lst==null)
            {
                return 0;
            }
            return lst.Sum(x => x.tongtien);
        }
        public List<itemcart> getcart()
        {
            List<itemcart> lst = Session["Cart"] as List<itemcart>;
            if(lst==null)
            {
                lst = new List<itemcart>();
                Session["Cart"] = lst;
            }
            return lst;
        }
        public ActionResult AddToCart(string mahh)
        {
            Quanao qa = db.Quanao.SingleOrDefault(x => x.Mahh == mahh);
            if (qa == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<itemcart> lst = getcart();
            itemcart item = lst.SingleOrDefault(x => x.mahh == mahh);
            if (item != null)
            {
                item.soluong++;
                item.tongtien = item.soluong * item.donggia;
                return Redirect("~/User/Cart/Index");
            }
            int soluong = int.Parse(Request["soluong"]);
            itemcart itC = new itemcart(mahh, soluong);
            lst.Add(itC);
            return Redirect("~/User/Cart/Index");
        }
        public ActionResult UpdateCart(string mahh)
        {
            List<itemcart> lst = getcart();
            itemcart item = lst.SingleOrDefault(x => x.mahh == mahh);
            int soluong = int.Parse(Request["soluong"]);
            item.soluong = soluong;
            item.tongtien = item.donggia * item.soluong;
            return Redirect("~/User/Cart/Index");
        }
        public ActionResult DeleteCart(string mahh)
        {
            List<itemcart> lst = getcart();
            itemcart item = lst.SingleOrDefault(x => x.mahh == mahh);
            lst.Remove(item);
            return Redirect("~/User/Cart/Index");
        }
        public int tinhtongtien2()
        {
            List<itemcart> lst = Session["Cart"] as List<itemcart>;
            if (lst == null)
            {
                return 0;
            }
            return lst.Sum(x => x.tongtien);
        }
        public ActionResult CheckOut()
        {
            List<itemcart> lst = getcart();
            Session["soluong"] = tinhsoluong();
            ViewBag.qty = tinhsoluong();
            ViewBag.tt = tinhtongtien2();
            ViewBag.tt2 = tinhtongtien2() + 30000;
            return View(lst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut([Bind(Include="Mahd,makh,ngayhd,tongtien,trangthai")]HoaDon hoadon)
        {
            hoadon.NgayHD = DateTime.Now;
            hoadon.TongTien = Convert.ToInt32(tinhtongtien());
            hoadon.TrangThai = "No";
            int count = Convert.ToInt32(db.HoaDon.Max(x=>x.MaHD));
            hoadon.MaHD = (count + 1).ToString();
            hoadon.MaNV = "NV1";
            hoadon.MaKH = "1";
            if(ModelState.IsValid)
            {
                db.HoaDon.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("AddProduct", "Cart");

            }
            return View(hoadon);
        }
        public ActionResult AddProduct([Bind(Include ="mahd,mahh,soluong")]CTHoaDon cTHoaDon)
        {
            var arr = db.HoaDon.OrderByDescending(u => u.MaHD).FirstOrDefault();
            List<itemcart> lst = getcart();
            var ll = new List<CTHoaDon>();
            foreach(var item in lst)
            {
                CTHoaDon tmp = new CTHoaDon();
                tmp.MaHD = arr.MaHD;
                tmp.Mahh = item.mahh;
                tmp.SoLuong = item.soluong;
                if(ModelState.IsValid)
                {
                    ll.Add(tmp);
                }
            }
            db.CTHoaDon.AddRange(ll.ToArray());
            db.SaveChanges();
            Session["Cart"] = null;
            Session["soluong"] = 0;
            return RedirectToAction("Index", "Home");
        }
    }
}