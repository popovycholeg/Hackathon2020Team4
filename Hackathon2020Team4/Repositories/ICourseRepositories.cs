using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon2020Team4.Models;
using Hackathon2020Team4.Data;
using Hackathon2020Team4.Controllers;

namespace Hackathon2020Team4.Repositories
{
    public interface ICourseRepositories
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesData(int studentId);
        IEnumerable<Module> GetModuleByCourseId(int courseId);
            

    }
}
