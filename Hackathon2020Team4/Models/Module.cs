using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Hackathon2020Team4.Data;
using System.ComponentModel.DataAnnotations;

namespace Hackathon2020Team4.Models
{
    public class Module
    {
        public int ID { get; set; }

        [DisplayName("Назва")]
        public string Title { get; set; }

        [DisplayName("Час заняття")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeStart { get; set; }

        [DisplayName("Існує лабораторна")]
        public bool IsLabExists { get; set; }

        [DisplayName("Існує Тест")]
        public bool IsTestExists { get; set; }

        public int CourseID { get; set; }

        [DisplayName("Курс")]
        public Course Course { get; set; }
    }
}
