using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataLibrary.Logic
{
    public static  class FormProcessor
    {
        public static  int CreateForm(string studentId, string fullName, string mobile, string emailAddress, string passedUnits, string avarage, string grade, string projectName, string projectDescription,string professorId,string managerId)
        {
            bool formSent = true;
            
            FormModel data = new FormModel
            {

                StudentId = studentId,
                FullName = fullName,
                Mobile = mobile,
                EmailAddress = emailAddress,
                PassedUnits = passedUnits,
                Avarage = avarage,
                Grade = grade,
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                ProfessorId = professorId,
                ManagerId = managerId,
                FormSent = formSent

            };
            string sql = @"insert into dbo.ProjectForm(StudentId, FullName, Mobile, EmailAddress, PassedUnits, Avarage, Grade, ProjectName, ProjectDescription, ProfessorId, ManagerId, FormSent)
                            values(@StudentId, @FullName, @Mobile, @EmailAddress, @PassedUnits, @Avarage, @Grade, @ProjectName, @ProjectDescription, @ProfessorId, @ManagerId, @FormSent );";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateForm( string username, string password)
        {
            Users data = new Users
            {
                Username = username,
                Password = password
            };
            string sql = @"insert into dbo.Users( Username, Password)
                            values( @Username, @Password);";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static  List<FormModel> LoadForm()
        {

            string sql = @"select  * from dbo.ProjectForm;";
            return SqlDataAccess.LoadData<FormModel>(sql);

        }

        public static List<FormModel> LoadForm(string username)
        {
            if (username != null)
            {
                string studentId = username;
                string professorId = username;
                string managerId = username;
                string sql = @"select  * from dbo.ProjectForm where StudentId=" + studentId + "or ProfessorId=" + professorId + "or ManagerId=" + managerId;
                return SqlDataAccess.LoadData<FormModel>(sql); 
            }
            else { return null; }


        }

        public static List<FormModel> LoadForm(int id)
        {

            string sql = @"select  * from dbo.ProjectForm where Id ="+id;
            return SqlDataAccess.LoadData<FormModel>(sql);

        }

        public static List<Users> LoadUser(string username)
        {
            try
            {
                string sql = @"select  * from dbo.Users where Username =" + username;
                return SqlDataAccess.LoadData<Users>(sql);
            }
            catch (Exception)
            {

                return null;
            }


        }
        //, string managerConfirmation, string managerConfirmationDate, string managerConfirmationComment
        public static int UpdateFormFromProfessor(int id, string professorConfirmation, string professorConfirmationDate, string professorConfirmationComment)
        {
            FormModel data = new FormModel
            {
                Id = id,
                ProfessorConfirmation = professorConfirmation,
                ProfessorConfirmationDate= professorConfirmationDate,
                ProfessorConfirmationComment = professorConfirmationComment
                //ManagerConfirmation = managerConfirmation,
                //ManagerConfirmationDate = managerConfirmationDate,
                //ManagerConfirmationComment = managerConfirmationComment
            };//, ManagerConfirmation = @ManagerConfirmation, ManagerConfirmationDate = @ManagerConfirmationDate, ManagerConfirmationComment = @ManagerConfirmationComment
            string sql = @"update dbo.ProjectForm set ProfessorConfirmation = @ProfessorConfirmation, ProfessorConfirmationDate= @ProfessorConfirmationDate, ProfessorConfirmationComment= @ProfessorConfirmationComment
                           where Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateFormFromManager(int id, string managerConfirmation, string managerConfirmationDate, string managerConfirmationComment)
        {
            FormModel data = new FormModel
            {
                Id = id,
                //ProfessorConfirmation = professorConfirmation,
                //ProfessorConfirmationDate = professorConfirmationDate,
                //ProfessorConfirmationComment = professorConfirmationComment
                ManagerConfirmation = managerConfirmation,
                ManagerConfirmationDate = managerConfirmationDate,
                ManagerConfirmationComment = managerConfirmationComment
            };
            string sql = @"update dbo.ProjectForm set ManagerConfirmation = @ManagerConfirmation, ManagerConfirmationDate = @ManagerConfirmationDate, ManagerConfirmationComment = @ManagerConfirmationComment
                           where Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }
        //, string professorConfirmation, string professorConfirmationDate, string managerConfirmation, string managerConfirmationDate, string managerConfirmationComment
        public static int UpdateFormFromStudent(int id, string mobile, string emailAddress, string passedUnits, string avarage, string projectName, string projectDescription)
        {//model.Id, model.FullName, model.Mobile, model.EmailAddress, model.PassedUnits, model.Avarage, model.Grade, model.ProjectName, model.ProjectDescription, model.ProfessorConfirmation, model.ProfessorConfirmationDate, model.ManagerConfirmation, model.ManagerConfirmationDate, model.ManagerConfirmationComment
            FormModel data = new FormModel
            {
                Id = id,
                //FullName = fullName,
                Mobile = mobile,
                EmailAddress = emailAddress,
                PassedUnits = passedUnits,
                Avarage = avarage,
                //Grade = grade,
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                //ProfessorConfirmation = professorConfirmation,
                //ProfessorConfirmationDate = professorConfirmationDate,
                //ManagerConfirmation = managerConfirmation,
                //ManagerConfirmationDate = managerConfirmationDate,
                //ManagerConfirmationComment = managerConfirmationComment
            };
            //,  ProfessorConfirmation = @ProfessorConfirmation, ProfessorConfirmationDate= @ProfessorConfirmationDate, ManagerConfirmation = @ManagerConfirmation, ManagerConfirmationDate = @ManagerConfirmationDate, ManagerConfirmationComment = @ManagerConfirmationComment
            string sql = @"update dbo.ProjectForm set  Mobile = @Mobile, EmailAddress = @EmailAddress, PassedUnits=@PassedUnits, Avarage= @Avarage, ProjectName=@ProjectName, ProjectDescription=@ProjectDescription
                           where Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static IEnumerable<ProfessorModel>LoadProfessor()
        {
            string sql = @"select  ProfessortId, ProfessorFullName from dbo.Professor;";//innerjoin by professor table
            return SqlDataAccess.LoadData<ProfessorModel>(sql);
        }

        public static IEnumerable<ProfessorModel> LoadProfessor(string professorId)
        {
            if (professorId !=null)
            {
                string sql = @"select  ProfessortId, ProfessorFullName from dbo.Professor where ProfessortId =" + professorId;//innerjoin by professor table
                return SqlDataAccess.LoadData<ProfessorModel>(sql);
            }
            else
            {
                return null;
            }

        }

        public static string GetsProfessor(IEnumerable<ProfessorModel> elements)
        {
            string professorName = "";
            if (elements != null)
            {
                foreach (var row in elements)
                {
                    professorName = row.ProfessorFullName;
                }
            }
            return professorName;
        }

        public static IEnumerable<SelectListItem> GetProfessor(IEnumerable<ProfessorModel>elements)
        {
            var data = new List<SelectListItem>();
            //List<ProfessorModel> Forms = new List<ProfessorModel>();

            foreach (var row in elements)
            {
                data.Add(new SelectListItem
                {
                    Value = row.ProfessortId,
                    Text = row.ProfessorFullName

                });
            }
            return data;
        }

        public static IEnumerable<ManagerModel> LoadManager()
        {
            string sql = @"select  ManagerId, ManagerFullName from dbo.Manager;";//innerjoin by professor table
            return SqlDataAccess.LoadData<ManagerModel>(sql);
        }

        public static IEnumerable<ManagerModel> LoadManager(string managerId)
        {
            string sql = @"select  ManagerId, ManagerFullName from dbo.Manager where ManagerId =" + managerId;//innerjoin by professor table
            return SqlDataAccess.LoadData<ManagerModel>(sql);
        }

        public static string GetsManager(IEnumerable<ManagerModel> elements)
        {
            string managerName="";
            foreach (var row in elements)
            {
                managerName = row.ManagerFullName;
            }
            return managerName;
        }

        public static IEnumerable<SelectListItem> GetManager(IEnumerable<ManagerModel> elements)
        {
            var data = new List<SelectListItem>();
            foreach (var row in elements)
            {
                data.Add(new SelectListItem
                {
                    Value = row.ManagerId,
                    Text = row.ManagerFullName

                });
            }
            return data;
        }



        public static IEnumerable<FormModel> LoadStudent(string studentId)
        {
            string sql = @"select  StudentId, FullName from dbo.ProjectForm where StudentId =" + studentId;
            return SqlDataAccess.LoadData<FormModel>(sql);
        }
        public static string GetsStudent(IEnumerable<FormModel> elements)
        {
            string studentName = "";
            foreach (var row in elements)
            {
                studentName = row.FullName;
            }
            return studentName;
        }


    }
}
