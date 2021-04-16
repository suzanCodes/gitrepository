using ResultPlusPlus.Models;
using ResultPlusPlus.Repositories;
using ResultPlusPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultPlusPlus.Controllers
{
    public class StudentController : Controller
    {
        IRepository<Student> _studentContext;
        IRepository<Class> _classContext; 
        // GET: Student
        public StudentController(IRepository<Student> studentcontext,IRepository<Class> classContext)
        {
            this._studentContext = studentcontext;
            this._classContext = classContext;

        }
        public ActionResult Index()
        {
            List<Student> students = _studentContext.Collection().ToList();
           
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            StudentRegistrationViewModel model = new StudentRegistrationViewModel();
            model.student = new Student();
            model.Classes = _classContext.Collection().ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_studentContext.Collection().Any(x => x.Email == model.student.Email)||
                    _studentContext.Collection().Where(x=>x.Class==model.student.Class).Any(x=>x.Rollno==model.student.Rollno))
                    //If email or sameroll in a class must be unique
                {
                    ModelState.AddModelError("", "Email or roll no duplicated ");
                }
                else
                {
                    Student student = new Student();
                    student.Name = model.FirstName + model.MiddleName + model.LastName;
                    student.Class = model.student.Class;
                    student.DOB = model.student.DOB;
                    student.Email = model.student.Email;
                    student.Rollno = model.student.Rollno;
                    _studentContext.Insert(student);
                    _studentContext.Commit();
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}