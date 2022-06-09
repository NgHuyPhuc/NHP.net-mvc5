using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wnct2.Areas.Admin.Models.DTO
{
    public class User
    {
        [Required(ErrorMessage = "Nhập Tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}