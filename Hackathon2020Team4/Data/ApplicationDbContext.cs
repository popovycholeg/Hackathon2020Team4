using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Hackathon2020Team4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hackathon2020Team4.Data
{
    public class ApplicationUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Здесь добавьте утверждения пользователя
        //    return userIdentity;
        //}

        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [DisplayName("Ім*я По-батькові")]
        public string FirstMidName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ModuleRating> ModuleRating { get; set; }
    }
}
