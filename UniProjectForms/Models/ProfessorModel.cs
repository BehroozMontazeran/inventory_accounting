using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniProjectForms.Models
{

    public class ProfessorModel
    {
        [Display(Name = "شماره پرسنلی")]
        [Range(10000000000000, 99999999999999, ErrorMessage = "شماره دانشجویی را صحیح وارد کنید")]
        public string ProfessortId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string ProfessorFullName { get; set; }


        [Display(Name = "سمت")]
        [Required(ErrorMessage = "استاد یا مدیر گروه بودن را انتخاب کنید")]
        public bool Official { get; set; }
    }
}