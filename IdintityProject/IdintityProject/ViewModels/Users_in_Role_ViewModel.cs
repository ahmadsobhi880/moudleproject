using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdintityProject.ViewModels
{
    public class Users_in_Role_ViewModel
    {
        
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public string Course { get; set; }


        [Display(Name = "Course - 2 ")]
        public string Course2 { get; set; }

        [Display(Name = "Course - 3 ")]
        public string Course3 { get; set; }


        [Display(Name = "Course - 4 ")]
        public string Course4 { get; set; }


        [Display(Name = "Course - 5 ")]
        public string Course5 { get; set; }


    }
}