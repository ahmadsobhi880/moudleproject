using IdintityProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdintityProject.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles

        public ActionResult Index()
        {
            if (User.IsInRole("Admins"))
            {

                return View(db.Roles.ToList());

            }

            return View("Error");

        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admins"))
            {
                var role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }

                return View(role);
            }
            else
            {
                return View("Error");

            }
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admins"))
            {
                return View();
            }
            else
            {
                return View("Error");


            }
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (User.IsInRole("Admins"))
            {
                try
                {

                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        db.Roles.Add(role);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    return View(role);
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

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admins"))
            {
                var role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }

                return View(role);

            }
            else
            {
                return View("Error");

            }
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")]IdentityRole role)
        {
            if (User.IsInRole("Admins"))
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(role);

            }
            else
            {
                return View("Error");

            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admins"))
            {
                var role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }

                return View(role);
            }
            else
            {
                return View("Error");

            }

        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole myRole)
        {
            if (User.IsInRole("Admins"))
            {

                // TODO: Add delete logic here
                IdentityRole role = db.Roles.Find(myRole.Id);
                db.Roles.Remove(role);
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
