using ResultPlusPlus.Models;
using ResultPlusPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultPlusPlus.Controllers
{
    public class SubjectController : Controller
    {
        IRepository<Subject> _subjectContext;
        public SubjectController(IRepository<Subject> subjectcontext)
        {
            this._subjectContext = subjectcontext;
        }
        // GET: Subject
        public ActionResult Index()
        {
            List<Subject> subjects = _subjectContext.Collection().ToList();

            return View(subjects);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            if(ModelState.IsValid)
            {
                _subjectContext.Insert(subject);
                _subjectContext.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}