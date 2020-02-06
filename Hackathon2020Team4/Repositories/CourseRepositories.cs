using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon2020Team4.Data;
using Hackathon2020Team4.Models;
using Hackathon2020Team4.Repositories;

namespace Hackathon2020Team4.Repositories
{
    public class CourseRepositories : ICourseRepositories
    {
        private ProjectContext _context;

        public CourseRepositories(ProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCupcakes()
        {
            return _context.Courses.ToList();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Student.ToList();
        }


        public IEnumerable<Module> GetModuleByCourseId(int courseId)
        {
            return _context.Module.Where(c => c.SudentId == courseId);
        }

        public IEnumerable<Course> GetCoursesData(int studentId)
        {
            return _context.Course.Where(c => c.SudentId == studentId);
        }
    }
}
