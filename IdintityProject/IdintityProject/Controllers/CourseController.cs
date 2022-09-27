using IdintityProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdintityProject.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Course
        public ActionResult Index()
        {


            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                return View(db.Course.ToList());

            }

            return View("Error");


        }


        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var course = db.Course.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }

                return View(course);
            }
            else
            {
                return View("Error");

            }
        }


        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var course = db.Course.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }

                return View(course);

            }
            else
            {
                return View("Error");

            }
        }


        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,CourseName,CourseDescription,Teacher_Course,CourseExam,Exam_Date,Exam_Moed,Course_Price")] CourseModel course)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(course);

            }
            else
            {
                return View("Error");

            }
        }


        // GET: Roles/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                var list = db.Users.Select(m => m.UserName).ToList();
                ViewBag.list = list;


                return View();
            }
            else
            {
                return View("Error");


            }
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(CourseModel course)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                try
                {

                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        db.Course.Add(course);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    return View(course);
                }
                catch
                {
                    return View();
                }
            }

            else
            {
                return View("Error");

            }
        }





        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var course = db.Course.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }

                return View(course);
            }
            else
            {
                return View("Error");

            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete( CourseModel course)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                // TODO: Add delete logic here
                CourseModel user = db.Course.Find(course.Id);
                db.Course.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            else
            {
                return View("Error");

            }
        }




        public ActionResult Prices()
        {



            return View(db.Course.ToList());


        }





    }
}
