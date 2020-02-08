using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackathon2020Team4.ViewModels;
using Hackathon2020Team4.Models;
using Microsoft.AspNetCore.Identity;
using Hackathon2020Team4.Data;
using Microsoft.EntityFrameworkCore;


namespace Hackathon2020Team4.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Email, LastName = model.LastName, FirstMidName = model.FirstMidName, EmailConfirmed = true }; 
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "entrant");
                    Student nSt = new Student
                    {
                        Institution = model.Institution,
                        Faculty = model.Faculty,
                        InstitutionCourse = model.InstitutionCourse,
                        AboutMe = model.AboutMe,
                        EnrollmentDate = DateTime.Now,
                        ApplicationUserID = user.Id
                    };

                    db.Students.Add(nSt);
                    db.SaveChanges();

                    // установка куки
                    // await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterInstructor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterInstructor(TeacherRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Email, LastName = model.LastName, FirstMidName = model.FirstMidName, EmailConfirmed = true };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "instructor");
                    Instructor nInst = new Instructor
                    {
                        ApplicationUserID = user.Id
                    };
                    db.Instructors.Add(nInst);
                    db.SaveChanges();
                    // установка куки
                    // await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}