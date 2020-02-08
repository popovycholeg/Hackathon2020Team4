using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackathon2020Team4.ViewModels;
using Hackathon2020Team4.Models;
using Hackathon2020Team4.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Hackathon2020Team4.Controllers
{
    [Authorize(Roles = "admin, instructor")]
    public class CourseController : Controller
    {
        private ApplicationDbContext db;

        public CourseController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Instructor).Include(c => c.Instructor.User);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Course course = db.Courses
                .Include(c => c.Modules)
                .Include(c => c.Enrollments)
                .Include(c => c.Enrollments.Select(e => e.Student))
                .Include(c => c.Enrollments.Select(e => e.Student.User))
                .FirstOrDefault(c => c.ID == id);
            if (course == null)
            {
                return StatusCode(404);
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            List<Instructor> instructors = db.Instructors.Include(i => i.User).ToList();
            ViewBag.InstructorID = new SelectList(instructors, "ID", "User.LastName");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create([Bind("ID,Title,StartDate,EndDate,ImageUrl,InstructorID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "ApplicationUserID", course.InstructorID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            Course course = db.Courses.Include(c => c.Modules).FirstOrDefault(c => c.ID == id);
            if (course == null)
            {
                return StatusCode(404);
            }

            List<Instructor> instructors = db.Instructors.Include(i => i.User).ToList();
            ViewBag.InstructorID = new SelectList(instructors, "ID", "User.LastName", course.InstructorID);

            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Title,StartDate,EndDate,ImageUrl,InstructorID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "ApplicationUserID", course.InstructorID);

            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return StatusCode(404);
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}