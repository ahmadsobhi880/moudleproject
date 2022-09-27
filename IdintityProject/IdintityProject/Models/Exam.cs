using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdintityProject.Models
{
    public class Exam
    {

        [Key]
        public int Id { get; set; }


        [Display(Name ="Exam Name")]
        [Required]
        public string Exam_Name { get; set; }


        [Display(Name = "Exam Date")]
        [Required]
        public DateTime Exam_Date { get; set; }


        

    }
}