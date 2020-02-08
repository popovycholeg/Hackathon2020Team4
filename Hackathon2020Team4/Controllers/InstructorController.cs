using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackathon2020Team4.Data;
using Hackathon2020Team4.Models;
using Hackathon2020Team4.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hackathon2020Team4.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationDbContext db;



        public InstructorController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
       /*     var students = from stud in db.Students
                           join user in db.Users on
                           stud.ApplicationUserID equals user.Id
                           select new
                           {
                               LastName = stud.User.LastName,
                               FirstMidName = stud.User.FirstMidName,
                               ID = stud.ID,
                               Faculty = stud.Faculty,
                               InstitutionCourse = stud.InstitutionCourse,
                               EnrollmentDate = stud.EnrollmentDate

                           };*/



          //  ViewBag.Students = students;
            return View();

        }

        [HttpGet]
        public IActionResult RateStudentCourses()
        {
            return View(db.Courses);
        }

        public IActionResult RateStudentModules(int ID)
        {

            return View(db.Modules.Where(mod=>mod.CourseID == ID));
        }

        [HttpGet]
        public IActionResult RateStudent(int ID)
        {
            ViewBag.Students = db.Students.Include(s => s.User);
            ViewBag.ModuleID = ID;
            return View();
        }

        [HttpGet]
        public IActionResult Rate(int ModuleID ,int StudentID)
        {
            ViewBag.ModuleID = ModuleID;
            ViewBag.StudentID = StudentID;
            return View();
        }

        [HttpPost]
        public IActionResult Rate(RateViewModel model)
        {
            if (model.LabRate < 0 || model.LabRate > 100 || model.TestRate > 25 || model.TestRate < 0)
            {
                return Content("Оцінки не відповідають стандартам оцінювання");
            }

            if (db.Enrollments.Where(st => st.ID == model.StudentID) == null)
            {
                return Content("Такий студент не зареєстрований");
            }

            ModuleRating moduleRating = new ModuleRating
            {
                LabRate = model.LabRate,
                TestRate = model.TestRate,
                EnrollmentID = model.StudentID,
                ModuleID = model.ModuleID,
               //ID = 1
            };

            db.ModuleRating.Add(moduleRating);

           // db.SaveChanges();

            return Content("Ok");
        }

/*        [HttpGet]
        public IActionResult ActualRate(RateViewModel model )
        {
            if (LabRate < 0 || LabRate >100 || TestRate > 25 || TestRate < 0)
            {
                return Content("Оцінки не відповідають стандартам оцінювання");
            }

            if (db.Enrollments.Where(st=>st.ID == StudentID) == null)
            {
                return Content("Такий студент не зареєстрований");
            }


            IEnumerable<Enrollment> enrolID = db.Enrollments.Where(en => en.ID == StudentID);


            ModuleRating moduleRating = new ModuleRating() { ModuleID = ModuleID, EnrollmentID = enrolID.Last().ID, LabRate = LabRate, TestRate = TestRate };

            db.ModuleRating.Add(moduleRating);
            db.SaveChanges();
            return Content("OK");
            return View();
        }
*/

    }
}