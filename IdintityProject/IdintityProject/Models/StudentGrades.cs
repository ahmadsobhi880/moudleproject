using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdintityProject.Models
{
    public class StudentGrades
    {

        [Key]
        public int Id { get; set; }

        
        public string StudName { get; set; }


        [Display(Name = "My Grade")]
        public string MyGrade { get; set; }


        [Display(Name = "Course ")]
        public string My_Course { get; set; }

    }
}