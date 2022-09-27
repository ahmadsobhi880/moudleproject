using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdintityProject.Models
{
    public class GradesModel
    {

        [Key]
        public int Id { get; set; }

   
        [Required]
        [Display(Name = "Student Name")]
        public string Student_Name { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Course_Name { get; set; }


        [Required]
        [Display(Name = "Grade")]
        public string Mygrade { get; set; }

    }
}