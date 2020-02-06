using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon2020Team4.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}