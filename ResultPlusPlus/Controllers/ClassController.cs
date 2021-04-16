using ResultPlusPlus.Models;
using ResultPlusPlus.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultPlusPlus.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        IRepository<Class> _context;
        public ClassController(IRepository<Class> context)
        {
            this._context = context;
        }

        public ActionResult Index()
        {
            List<Class> classes = _context.Collection().ToList();
            return View(classes);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Class model)
        {
           if(ModelState.IsValid)
            {
                bool IsRepeated = _context.Collection().Any(x => x.ClassName == model.ClassName);
                if (IsRepeated)
                {
                    ModelState.AddModelError("", "Name has already been taken");
                    return View();
                }
                else
                {

                    _context.Insert(model);
                    _context.Commit();
                }
            }
           else
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            if(ModelState.IsValid)
            {
                Class model = _context.Find(Id);
                if(model!=null)
                {
                    _context.Delete(Id);
                    _context.Commit();
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Class model = _context.Collection().Where(x => x.Id == Id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Class model)
        {
            if(ModelState.IsValid)
            {
                _context.Edit(model);
                _context.Commit();
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");
        }




    }
    
 }