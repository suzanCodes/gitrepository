using ResultPlusPlus.Models;
using ResultPlusPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultPlusPlus.Controllers
{
    public class ResultController : Controller
    {
        IRepository<Class> _classContext;
        IRepository<Student> _studentContext;
        public ResultController(IRepository<Class> _context,IRepository<Student> studentContext)
        {
            this._classContext = _context;
            this._studentContext = studentContext;
        }

        // GET: Result
        public ActionResult ClassIndex()
        {
            List<Class> classes = _classContext.Collection().ToList();

            return View(classes);
        }
        public ActionResult StudentIndex(int classId)
        {
            Class Class = _classContext.Collection().Where(x => x.Id == classId).FirstOrDefault();//class Data
            List<Student> students = _studentContext.Collection().Where(x => x.Class == Class.ClassName).ToList();
           
                                      
            return View(students);
        }
        

    }
}