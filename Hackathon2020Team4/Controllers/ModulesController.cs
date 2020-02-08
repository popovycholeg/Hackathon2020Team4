using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackathon2020Team4.Models;
using Hackathon2020Team4.Data;
using Hackathon2020Team4.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hackathon2020Team4.Controllers
{
    public class ModulesController : Controller
    {
        private ApplicationDbContext db;

        public ModulesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Modules
        public IActionResult Index()
        {
            var modules = db.Modules.Include(m => m.Course);
            return View(modules.ToList());
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            Module module = db.Modules.Include(m => m.Course).FirstOrDefault(m => m.ID == id);


            if (module == null)
            {
                return StatusCode(404);
            }

            List<ModuleRating> rating = db.ModuleRating
                .Include(mr => mr.Enrollment)
                .Include(mr => mr.Enrollment.Student)
                .Where(mr => mr.ModuleID == id)
                .ToList();

            ViewBag.Rating = rating;

            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", id);
            return View();
        }

        // POST: Modules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Module module)
        {
            if (ModelState.IsValid)
            {
                Module newModule = new Module
                {
                    Title = module.Title,
                    DateTimeStart = module.DateTimeStart,
                    IsLabExists = module.IsLabExists,
                    IsTestExists = module.IsTestExists,
                    CourseID = module.CourseID
                };

                db.Modules.Add(newModule);
                db.SaveChanges();
                return RedirectToAction("Index", "Course");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", new { area = module.CourseID });
            return View(module);
        }











        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return StatusCode(404);
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", module.CourseID);
            return View(module);
        }
        // POST: Modules/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Title,IsLabExists,IsTestExists,CourseID")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", module.CourseID);
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return StatusCode(404);
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}
