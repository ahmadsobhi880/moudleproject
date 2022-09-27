using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdintityProject.Models;

namespace IdintityProject.Controllers
{
    public class StudentCoursesController : Controller
    {
        public ApplicationDbContext db;

        public StudentCoursesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: StudentCourses
        public ActionResult Index()
        {
            var lst =db.GradesModel.Where(d => d.Student_Name == User.Identity.Name).ToList();
            return View(lst);
        }




        public ActionResult Exams()
        {

            return View(db.Course.ToList());
        }
    }
}
