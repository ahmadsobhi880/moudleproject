using System;
using System.Collections.Generic;
using System.Linq;

using IdintityProject.Models;
using IdintityProject.ViewModels;
using System.Data.Entity;

using System.Web;
using System.Web.Mvc;
using System.IO;




namespace IdintityProject.Controllers
{
    public class HomeWorksController : Controller
    {
        public ApplicationDbContext db;
        public HomeWorksController()
        {
            db = new ApplicationDbContext();
        }
        // GET: HomeWorks
        public ActionResult Index()
        {

            if (User.IsInRole("Students")|| User.IsInRole("Teachers"))
            {

                return View(db.HomeWorksModel.ToList());

            }

            return View("Error");
        }

        // GET: HomeWorks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeWorks/Create
        public ActionResult Create()
        {
            return View();

        }


        // POST: HomeWorks/Create
        [HttpPost]
        public ActionResult Create(HomeWorksModel obj)
        {
            if (User.IsInRole("Teachers"))
            {
                try { 
            
                        string path = Server.MapPath("~/UploadedFile");
                        string fileName = Path.GetFileName(obj.File.FileName);

                        string fullPath = Path.Combine(path, fileName);

                        obj.File.SaveAs(fullPath);
                
                        obj.homeworkFile = "/UploadedFile/" +fileName;

                        // TODO: Add insert logic here
                        if (ModelState.IsValid)
                        {
                            db.HomeWorksModel.Add(obj);
                            db.SaveChanges();
                            return RedirectToAction("index");

                        }
                        return View(obj);

                }

                catch (Exception ex)
                {
                    return View(ex);
                }


            }
            else
            {
                return View("Dashboard");
            }



        }
        // GET: HomeWorks/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Teachers"))
            {
                var homework = db.HomeWorksModel.Find(id);
                if (homework == null)
                {
                    return HttpNotFound();
                }

                return View(homework);



            }
            else
            {
                return View("Dashboard");
            }


        }

        // POST: HomeWorks/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,homeworkName,homeworkDesc,homeworkFile")] HomeWorksModel homework)
        {
            if (User.IsInRole("Teachers"))
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(homework).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(homework);



            }
            else
            {
                return View("Dashboard");
            }


        }



        // GET: HomeWorks/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.IsInRole("Teachers"))
            {
                var homework = db.HomeWorksModel.Find(id);
                if (homework == null)
                {
                    return HttpNotFound();
                }

                return View(homework);



            }
            else
            {
                return View("Dashboard");
            }

        }

        // POST: HomeWorks/Delete/5
        [HttpPost]
        public ActionResult Delete(HomeWorksModel homework)
        {

            if (User.IsInRole("Teachers"))
            {
                // TODO: Add delete logic here
                HomeWorksModel Homee = db.HomeWorksModel.Find(homework.Id);
                db.HomeWorksModel.Remove(Homee);
                db.SaveChanges();
                return RedirectToAction("RequestsForUsers");

            }
            else
            {
                return View("Dashboard");
            }

           
        }
    }
}
