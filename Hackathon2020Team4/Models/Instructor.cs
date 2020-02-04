﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon2020Team4.Data;

namespace Hackathon2020Team4.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
