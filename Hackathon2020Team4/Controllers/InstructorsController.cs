using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackathon2020Team4.Repositories;
using Hackathon2020Team4.Data;


namespace Hackathon2020Team4.Controllers
{
    public class InstructorsController : Controller
    {
        private ICourseRepositories _repository;

        public InstructorsController(ICourseRepositories repositories)
        {
            _repository = repositories;
        }
        public IActionResult GetStudents()
        {
            return View(_repository.GetStudents());
        }
    }
}