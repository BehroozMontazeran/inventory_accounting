using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProjectForms.Models;
using DataLibrary;


namespace UniProjectForms.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registers()
        {
            return View();
        }

        public ActionResult Logins()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Form", new {username = Session["username"].ToString() });
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult LogOffs()
        {
            Session.Abandon();
            return RedirectToAction("Logins");
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        //[Authorize(Roles = "Student")]

        public ActionResult ViewForms(string username)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Logins", "Home");
            }
            else
            {
                username = Session["username"].ToString();
                ViewBag.Username = username;
                ViewBag.Message = "List Forms";
                //if (username.Substring(0, 1) == "9")
                //{
                //    ViewBag.Message = "List Forms";
                //}
                var data = DataLibrary.Logic.FormProcessor.LoadForm(username);
                List<FormModel> Forms = new List<FormModel>();
                foreach (var row in data)
                {
                    ViewBag.ProfessorConfirmation = row.ProfessorConfirmation;
                    ViewBag.ManagerConfirmation = row.ManagerConfirmation;
                    ViewBag.ProfessorId = row.ProfessorId;
                    ViewBag.ManagerId = row.ManagerId;
                    Forms.Add(new FormModel
                    {
                        Id = row.Id,
                        Mobile = row.Mobile,
                        EmailAddress = row.EmailAddress,
                        PassedUnits = row.PassedUnits,
                        Avarage = row.Avarage,
                        Grade = row.Grade,
                        FullName = row.FullName,
                        StudentId = row.StudentId,
                        ProjectName = row.ProjectName,
                        ProjectDescription = row.ProjectDescription,
                        ProfessorId = row.ProfessorId,
                        ManagerId = row.ManagerId,
                        ProfessorConfirmation = row.ProfessorConfirmation,
                        ProfessorConfirmationDate = row.ProfessorConfirmationDate,
                        ProfessorConfirmationComment = row.ProfessorConfirmationComment,
                        ManagerConfirmation = row.ManagerConfirmation,
                        ManagerConfirmationDate = row.ManagerConfirmationDate,
                        ManagerConfirmationComment = row.ManagerConfirmationComment
                        
                    });
                }
                return View(Forms);
            }
        }

        //[Authorize(Roles = "Professor")]
        public ActionResult ProfessorEdit(int id)
        {
            ViewBag.Message = "ProfessorEdit";
            var data = DataLibrary.Logic.FormProcessor.LoadForm(id);
            FormModel Forms = new FormModel();

            foreach (var row in data)
            {
                Forms.StudentId = row.StudentId;
                Forms.FullName = row.FullName;
                Forms.ProjectName = row.ProjectName;
                Forms.ProjectDescription = row.ProjectDescription;
                Forms.ProfessorConfirmation = row.ProfessorConfirmation;
                Forms.ProfessorConfirmationDate= row.ProfessorConfirmationDate;
                Forms.ProfessorConfirmationComment = row.ProfessorConfirmationComment;
                Forms.ManagerConfirmation = row.ManagerConfirmation;
                Forms.ManagerConfirmationDate = row.ManagerConfirmationDate;
                Forms.ManagerConfirmationComment = row.ManagerConfirmationComment;   
            }
            return View(Forms);
        }

        public ActionResult ManagerEdit(int id)
        {
            ViewBag.Message = "ManagerEdit";
            var data = DataLibrary.Logic.FormProcessor.LoadForm(id);
            FormModel Forms = new FormModel();

            foreach (var row in data)
            {
                Forms.StudentId = row.StudentId;
                Forms.FullName = row.FullName;
                Forms.ProjectName = row.ProjectName;
                Forms.ProjectDescription = row.ProjectDescription;
                Forms.ProfessorConfirmation = row.ProfessorConfirmation;
                Forms.ProfessorConfirmationDate = row.ProfessorConfirmationDate;
                Forms.ProfessorConfirmationComment = row.ProfessorConfirmationComment;
                Forms.ManagerConfirmation = row.ManagerConfirmation;
                Forms.ManagerConfirmationDate = row.ManagerConfirmationDate;
                Forms.ManagerConfirmationComment = row.ManagerConfirmationComment;
            }
            return View(Forms);
        }
        public ActionResult StudentEdit(int id)
        {
            ViewBag.Message = "StudentEdit";
            var data = DataLibrary.Logic.FormProcessor.LoadForm(id);
            FormModel Forms = new FormModel();

            foreach (var row in data)
            {
                Forms.StudentId = row.StudentId;
                Forms.FullName = row.FullName;
                Forms.Mobile = row.Mobile;
                Forms.PassedUnits = row.PassedUnits;
                Forms.EmailAddress = row.EmailAddress;
                Forms.Avarage = row.Avarage;
                Forms.Grade = row.Grade;
                Forms.ProjectName = row.ProjectName;
                Forms.ProjectDescription = row.ProjectDescription;
                Forms.ProfessorConfirmation = row.ProfessorConfirmation;
                Forms.ProfessorConfirmationDate = row.ProfessorConfirmationDate;
                Forms.ProfessorConfirmationComment = row.ProfessorConfirmationComment;
                Forms.ManagerConfirmation = row.ManagerConfirmation;
                Forms.ManagerConfirmationDate = row.ManagerConfirmationDate;
                Forms.ManagerConfirmationComment = row.ManagerConfirmationComment;
            }
            return View(Forms);
        }

        public ActionResult Form(string username)//get the request of form to be filled
        {
            bool formSent = false;
            
            if (Session["username"] != null)
            {
                username = Session["username"].ToString();
            }
            var data = DataLibrary.Logic.FormProcessor.LoadForm(username);
            
            if (data != null)
            {
                foreach (var row in data)
                { formSent = row.FormSent; }
            }
            if (Session["username"] == null)
            {
                return RedirectToAction("Logins","Home");
            }
            else if (Session["username"].ToString().Substring(0, 1) == "9" && formSent == false )
            {
                ViewBag.Message = "Student Form";
                ViewBag.Username = username;
                return View();
            }
            else
            {
                return RedirectToAction("ViewForms", new { username });
            }
        }
        [HttpPost]
        public ActionResult Registers(Users model)
        {
            int recordsCreated = DataLibrary.Logic.FormProcessor.CreateForm(model.Username, model.Password);

            return RedirectToAction("Form", new { username = model.Username });

        }
        [HttpPost]
        public ActionResult Logins(Users model)
        {
            var data = DataLibrary.Logic.FormProcessor.LoadUser(model.Username);
            bool UserEqual = false;
            bool PassEqual = false;
            Session["username"] = model.Username;
           // ViewBag.Username = "";
            Session["Name"] = "";

            if (data != null)
            {
                foreach (var row in data)
                {
                    UserEqual = model.Username.Equals(row.Username);
                    PassEqual = model.Password.Equals(row.Password);
                }
                if (UserEqual && PassEqual)
                {

                    if (Session["username"].ToString().Substring(0, 1) == "2")
                    {
                        Session["Name"] = DataLibrary.Logic.FormProcessor.GetsManager(DataLibrary.Logic.FormProcessor.LoadManager(Session["username"].ToString()));
                        return RedirectToAction("ViewForms", new { username = model.Username });
                    }
                    else if (Session["username"].ToString().Substring(0, 1) == "1")
                    {
                        Session["Name"] = DataLibrary.Logic.FormProcessor.GetsProfessor(DataLibrary.Logic.FormProcessor.LoadProfessor(Session["username"].ToString()));
                        return RedirectToAction("ViewForms", new { username = model.Username });
                    }
                    else if (Session["username"].ToString().Substring(0, 1) == "9")
                    {
                        Session["Name"] = DataLibrary.Logic.FormProcessor.GetsStudent(DataLibrary.Logic.FormProcessor.LoadStudent(Session["username"].ToString()));

                        if (Session["Name"].ToString()!="")
                        {
                            return RedirectToAction("ViewForms", new { username = model.Username });
                        }
                    }
                    else
                    {
                        Session["Name"] = "بعنوان میهمان";
                        return RedirectToAction("Form", new { username = model.Username });
                    }

                    //return RedirectToAction("Form", new {username = model.Username });
                    Session["Name"] = "بعنوان میهمان";
                    return RedirectToAction("Form", new { username = model.Username });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        //[Authorize(Roles = "Professor")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ProfessorEdit(FormModel model)//send the request of form after to be filled
        {//, model.ManagerConfirmation, model.ManagerConfirmationDate, model.ManagerConfirmationComment
            int recordsCreated = DataLibrary.Logic.FormProcessor.UpdateFormFromProfessor(model.Id, model.ProfessorConfirmation, model.ProfessorConfirmationDate,model.ProfessorConfirmationComment);

            return RedirectToAction("ViewForms");  
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ManagerEdit(FormModel model)//send the request of form after to be filled
        {
            int recordsCreated = DataLibrary.Logic.FormProcessor.UpdateFormFromManager(model.Id, model.ManagerConfirmation, model.ManagerConfirmationDate, model.ManagerConfirmationComment);

            return RedirectToAction("ViewForms");
        }


        [HttpPost]
        public ActionResult StudentEdit(FormModel model)//send the request of form after to be filled
        {//, model.ProfessorConfirmation, model.ProfessorConfirmationDate, model.ManagerConfirmation, model.ManagerConfirmationDate, model.ManagerConfirmationComment
            int recordsCreated = DataLibrary.Logic.FormProcessor.UpdateFormFromStudent(model.Id, model.Mobile, model.EmailAddress, model.PassedUnits, model.Avarage, model.ProjectName, model.ProjectDescription);

            return RedirectToAction("ViewForms");

            //if (ModelState.IsValid)
            //{
            //    return View();
            //}


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Student")]
        public ActionResult Form(FormModel model)
        {
            string StudentId = Session["username"].ToString();
            //if (ModelState.IsValid)
            //{
                int recordsCreated = DataLibrary.Logic.FormProcessor.CreateForm(StudentId, model.FullName, model.Mobile, model.EmailAddress, model.PassedUnits, model.Avarage, model.Grade, model.ProjectName, model.ProjectDescription, model.ProfessorId, model.ManagerId);

                return RedirectToAction("Index");
            //}

            //return View();
        }

    }
}