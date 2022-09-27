using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdintityProject.Models;

namespace IdintityProject.Controllers
{
    public class StudentGradesController : Controller
    {

        public ApplicationDbContext db;

        public StudentGradesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: StudentGrades
        public ActionResult Index()
        {
            var aa = db.GradesModel.Where(d => d.Student_Name == User.Identity.Name).ToList();

            return View(aa);
        }


        
    }
}