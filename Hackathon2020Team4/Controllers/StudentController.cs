using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon2020Team4.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon2020Team4.Controllers
{
    public class StudentController : Controller
    {
        // private ApplicationDbContext _context;
        //public StudentController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Course/{id}")]
        public IActionResult Course(int id)
        {
            return View();
        }

        public IActionResult Marks()
        {
            return View();
        }

        public IActionResult Rate()
        {
            return View();
        }
    }
}