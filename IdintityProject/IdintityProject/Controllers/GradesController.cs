using IdintityProject.Models;
using IdintityProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdintityProject.Controllers
{
    public class GradesController : Controller
    {
       public ApplicationDbContext db;

        public GradesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Grades
        public ActionResult Index()
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                return View(db.GradesModel.ToList());

            }

            return View("Error");
        }

        // GET: Grades/Details/5
        public ActionResult Details(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var grade = db.GradesModel.Find(id);
                if (grade == null)
                {
                    return HttpNotFound();
                }

                return View(grade);
            }
            else
            {
                return View("Error");

            }
        }

        

        // GET: Grades/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var grade = db.GradesModel.Find(id);
                if (grade == null)
                {
                    return HttpNotFound();
                }

                return View(grade);

            }
            else
            {
                return View("Error");

            }
        }

        // POST: Grades/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Student_Name,Course_Name,Mygrade")] GradesModel grade)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(grade).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(grade);

            }
            else
            {
                return View("Error");

            }
        }


        // GET: Grades/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var list = db.Users.Select( m => m.UserName).ToList();
                ViewBag.list = list;

                //ViewBag.Roles = new SelectList(db.Roles.Where(a => !a.Name.Contains("Admins")), "Name", "Name");

                var list2 = db.Course.Select(m => m.CourseName).ToList();
                ViewBag.list2 = list2;

                return View();
            }
            else
            {
                return View("Error");


            }
        }


        // POST: Grades/Create
        [HttpPost]
        public ActionResult Create(GradesModel grade)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                try
                {

                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        db.GradesModel.Add(grade);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    return View(grade);
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


        // GET: Grades/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {
                var grade = db.GradesModel.Find(id);
                if (grade == null)
                {
                    return HttpNotFound();
                }

                return View(grade);
            }
            else
            {
                return View("Error");

            }
        }

        // POST: Grades/Delete/5
        [HttpPost]
        public ActionResult Delete(GradesModel myGrade)
        {
            if (User.IsInRole("Admins") || User.IsInRole("Teachers"))
            {

                // TODO: Add delete logic here
                GradesModel grade = db.GradesModel.Find(myGrade.Id);
                db.GradesModel.Remove(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            else
            {
                return View("Error");

            }
        }


    }
}
