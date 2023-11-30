using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataLibrary.Models
{
    public class ProfessorModel
    {

        public string ProfessortId { get; set; }

        public string ProfessorFullName { get; set; }

        public IEnumerable<SelectListItem> ProfessorList { get; set; }

        public bool Official { get; set; }


    }
}
