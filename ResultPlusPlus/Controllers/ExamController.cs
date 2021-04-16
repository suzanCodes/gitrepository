using ResultPlusPlus.Models;
using ResultPlusPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultPlusPlus.Controllers
{
    public class ExamController : Controller
    {
        IRepository<Exam> _examcContext;
        public ExamController(IRepository<Exam> examcontext)
        {
            _examcContext = examcontext;
        }
        // GET: Exam
        public ActionResult Index()
        {
            List<Exam> exams = _examcContext.Collection().ToList();
            return View(exams);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            if(ModelState.IsValid)
            {
                _examcContext.Insert(exam);
                _examcContext.Commit();
                 return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}