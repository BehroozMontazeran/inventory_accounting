using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
   public class FormModel
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string PassedUnits { get; set; }
        public string Avarage { get; set; }
        public string Grade { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProfessorFullName { get; set; }
        public string ProfessorId { get; set; }
        public string ProfessorConfirmation { get; set; }
        public string ProfessorConfirmationDate { get; set; }
        public string ProfessorConfirmationComment { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerId { get; set; }
        public string ManagerConfirmation { get; set; }
        public string ManagerConfirmationDate { get; set; }
        public string ManagerConfirmationComment { get; set; }
        public bool FormSent { get; set; }
    }
}
