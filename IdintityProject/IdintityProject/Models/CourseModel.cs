using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdintityProject.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Course name")]
        public string CourseName { get; set; }


        [Display(Name = "Course description")]
        public string CourseDescription { get; set; }



        [Display(Name = "Course Price")]
        public string Course_Price { get; set; }


        [Required]
        [Display(Name = "Course Teacher")]
        public string Teacher_Course { get; set; }


        [Display(Name = "Course Exam")]

        public string CourseExam { get; set; }


        [Display(Name = "Exam Date")]
        public string Exam_Date { get; set; }


        [Display(Name = "Exam Moed")]
        public string Exam_Moed { get; set; }

    }
}