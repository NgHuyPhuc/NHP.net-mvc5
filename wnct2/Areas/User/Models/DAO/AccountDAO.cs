using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wnct2.Models.Framework;

namespace wnct2.Areas.User.Models.DAO
{
    
    public class AccountDAO
    {
        private static wnct1Entities db = new wnct1Entities();
        public AccountDAO()
        {

        }
        public static bool checkLogin(string UserName, string Passwords)
        {
            // Hash password before check

            int num = db.NguoiDung.Count(x => x.TaiKhoan == UserName && x.MatKhau == Passwords);
            return num == 1;
        }
    }
}