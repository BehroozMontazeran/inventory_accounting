using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniProjectForms.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "کد")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "این مرورگر را بخاطر داشته باش؟")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول پسورد باید حداقل 8 کارامتر باشد", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید پسورد")]
        [Compare("Password", ErrorMessage = "پسورد مطابقت ندارد")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول پسورد باید حداقل 8 کارامتر باشد", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید پسورد")]
        [Compare("Password", ErrorMessage = "پسورد مطابقت ندارد")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        //[Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید")]
        public string Email { get; set; }
    }
}
