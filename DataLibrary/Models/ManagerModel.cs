using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataLibrary.Models
{
    public class ManagerModel
    {
        public string ManagerId { get; set; }

        public string ManagerFullName { get; set; }

        public IEnumerable<SelectListItem> ManagerList { get; set; }

        public bool Official { get; set; }
    }
}
