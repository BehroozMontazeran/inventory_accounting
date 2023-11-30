using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace UniProjectForms.Models
{
    public class Users
    {
        //[Key]
        public int Id { get; set; }

        [Display(Name = "  شماره دانشجویی یا کد پرسنلی")]
        [Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی یا کد پرسنلی را صحیح وارد کنید")]
        [Required(ErrorMessage = "شماره دانشجویی یا کد پرسنلی را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز عبور معتبر را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تایید رمز عبور")]
        [Required(ErrorMessage = "عبارت وارد شده با رمز عبور مطابقت ندارد")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}