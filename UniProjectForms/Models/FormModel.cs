using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniProjectForms.Models
{
    public class FormModel
    {
        public int Id { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        [Required(ErrorMessage = "شماره دانشجویی را وارد کنید")]
        public string StudentId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "شماره موبایل را وارد کنید")]
        [Range(9000000000, 9999999999, ErrorMessage = "شماره همراه را بدون صفر اولیه وارد کنید")]
        public string Mobile { get; set; }


        [Display(Name = "آدرس ایمیل")]
        [Required(ErrorMessage = "آدرس ایمیل معتبر وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Display(Name = "واحد گذرانده")]
        [Required(ErrorMessage = "تعداد واحد گذرانده را وارد کنید")]
        [Range(30, 180, ErrorMessage = "تعداد واحد گذرانده باید بیشتر از 30 واحد باشد")]
        public string PassedUnits { get; set; }

        [Display(Name = "معدل کل")]
        [Required(ErrorMessage = "معدل کل را وارد کنید")]
        [Range(10.00,20.00, ErrorMessage = "معدل کل را صحیح وارد کنید")]
        public string Avarage { get; set; }

        [Display(Name = "مقطع تحصیلی")]
        [Required(ErrorMessage = "مقطع تحصیلی را وارد کنید")]
        public string Grade { get; set; }

        [Display(Name = "موضوع پروژه")]
        [Required(ErrorMessage = "موضوع پروژه پیشنهادی را وارد کنید")]
        public string ProjectName { get; set; }


        [Display(Name = "شرح پروژه")]
        [Required(ErrorMessage = "شرح و مختصری از پروژه پیشنهادی را وارد کنید")]
        public string ProjectDescription { get; set; }


        [Display(Name = " استاد راهنما")]
        //[Required(ErrorMessage = "نام و نام خانوادگی استاد راهنما را وارد کنید")]
        public string ProfessorFullName { get; set; }

        [Display(Name = " کد استاد راهنما ")]
        [Required(ErrorMessage = "نام و نام خانوادگی استاد راهنما را وارد کنید")]
        public string ProfessorId { get; set; }

        [Display(Name = "نظر استاد راهنما")]
        public string ProfessorConfirmation { get; set; }


        [Display(Name = "تاریخ تاییداستاد")]
        [DataType(DataType.Date)]
        public string ProfessorConfirmationDate { get; set; }

        [Display(Name = "نظر استاد راهنما")]
        public string ProfessorConfirmationComment { get; set; }


        [Display(Name = "مدیر گروه")]
        //[Required(ErrorMessage = "نام و نام خانوادگی مدیر گروه را وارد کنید")]
        public string ManagerFullName { get; set; }

        [Display(Name = "کد مدیر گروه")]
        [Required(ErrorMessage = "نام و نام خانوادگی مدیر گروه را وارد کنید")]
        public string ManagerId { get; set; }


        [Display(Name = "وضعیت پروژه")]
        public string ManagerConfirmation { get; set; }


        [Display(Name = "تاریخ تایید مدیر گروه")]
        [DataType(DataType.Date)]
        public string ManagerConfirmationDate { get; set; }


        [Display(Name = "نظر مدیر گروه")]
        public string ManagerConfirmationComment { get; set; }

        public bool FormSent { get; set; }



    }
}