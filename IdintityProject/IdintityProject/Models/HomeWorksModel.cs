using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdintityProject.Models;

namespace IdintityProject.Models
{
    public class HomeWorksModel
    {
        public int Id { get; set; }

        [DisplayName("Home Work For Course :")]
        public string homeworkName { get; set; }


        [DisplayName("Home Work Description :")]
        public string homeworkDesc { get; set; }



        [DisplayName("Home Work download file ")]
        public string homeworkFile { get; set; }


        [NotMappedAttribute]
        public HttpPostedFileBase File { get; set; }


    }
}