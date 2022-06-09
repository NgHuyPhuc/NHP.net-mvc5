using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wnct2.Models.Framework
{
    public class itemcart
    {
        public string mahh { get; set; }
        public string tenhh { get; set; }
        public string producer { get; set; }
        public string anh { get; set; }
        public int donggia { get; set; }
        public int soluong { get; set; }
        public int tongtien { get; set; }
        public string type { get; set; }
        
        public itemcart(string id,int sl)
        {
            using (wnct1Entities db = new wnct1Entities())
            {
                this.mahh = id;
                Quanao qa = db.Quanao.Single(x => x.Mahh == id);
                this.tenhh = qa.Tenhh;
                this.anh = qa.Anh;
                this.type = qa.Type;
                this.donggia = qa.DongGia.Value;
                this.soluong = sl;
                this.tongtien = donggia * soluong;
            }
        }
    }
}