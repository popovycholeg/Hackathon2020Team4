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
using Microsoft.AspNetCore.Identity;

namespace Hackathon2020Team4.Controllers
{
    [Authorize(Roles = "admin, instructor, student")]
    public class CourseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext db;

        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        // GET: Course
        public async Task<ActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
                return StatusCode(409);
            }
            else if (roles[0] == "admin" || roles[0] == "student") // admin
            {
                var courses = db.Courses.Include(c => c.Instructor).Include(c => c.Instructor.User);
                return View(courses.ToList());
            }
            else // instructor
            {
                var courses = db.Courses.Include(c => c.Instructor).Include(c => c.Instructor.User).Where(c => c.Instructor.User.Id == user.Id);
                return View(courses.ToList());
            }


            // return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }
            Course course = db.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Instructor.User)
                .Include(c => c.Modules)
                .FirstOrDefault(c => c.ID == id);
            if (course == null)
            {
                return StatusCode(404);
            }
            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "admin, instructor")]
        public ActionResult Create()
        {
            List<Instructor> instructors = db.Instructors.Include(i => i.User).ToList();
            ViewBag.InstructorID = new SelectList(instructors, "ID", "User.LastName");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [Authorize(Roles = "admin, instructor")]
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
        [Authorize(Roles = "admin, instructor")]
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
        [Authorize(Roles = "admin, instructor")]
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
        [Authorize(Roles = "admin, instructor")]
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
        [Authorize(Roles = "admin, instructor")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        ////[Authorize(Roles = "student")]
        //public async Task<ActionResult> JoinToCourseAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return StatusCode(400);
        //    }

        //    var user = await _userManager.GetUserAsync(HttpContext.User);
        //    var student = db.Students.Include(s => s.User).FirstOrDefault(s => s.User.Id == user.Id);

        //    Enrollment newEnr = new Enrollment
        //    {
        //        CourseID = Convert.ToInt32(id),
        //        StudentID = student.ID
        //    };



        //    return RedirectToAction("Index");
        //    return View();
        //}

        public async Task<ActionResult> ToCourse(int? id)
        {
            if (id == null)
            {
                return StatusCode(400);
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var student = db.Students.Include(s => s.User).FirstOrDefault(s => s.User.Id == user.Id);

            Enrollment newEnr = new Enrollment
            {
                CourseID = Convert.ToInt32(id),
                StudentID = student.ID
            };

            db.Enrollments.Add(newEnr);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}