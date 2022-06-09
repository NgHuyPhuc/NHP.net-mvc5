using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wnct2.Areas.User.Models.DTO
{
    public class UserModel
    {
        [Required(ErrorMessage = "Not null")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Not null")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}