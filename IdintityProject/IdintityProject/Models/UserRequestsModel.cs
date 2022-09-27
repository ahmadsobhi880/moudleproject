using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations.Schema;
using IdintityProject.Models;

namespace IdintityProject.Models
{
    public class UserRequestsModel
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name ="Full Name")]
        public string FullNameRequests { get; set; }

        [Required]
        [Display(Name = "Email")]

        public string EmailRequests { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumberRequests { get; set; }


    }
}