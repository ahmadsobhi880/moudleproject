using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdintityProject.Models
{
    public class StudentRequest
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Name")]
        public string UserNameRequest { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailRequest { get; set; }


        [Required]
        [Display(Name = "Subject")]
        public string SubjectName { get; set; }



        [Required]
        [Display(Name = "Message")]
        public string messageRequest { get; set; }


        [Display(Name = "Status")]
        public string RequestStatus { get; set; }


       public StudentRequest()
        {
            RequestStatus = "Pending";
        }
        
    }
}