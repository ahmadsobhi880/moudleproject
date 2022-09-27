using IdintityProject.Models;
using IdintityProject.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace IdintityProject.Controllers
{

    public class ManageUsersController : Controller
    {

        private ApplicationDbContext db;

        public ManageUsersController()
        {
            db = new ApplicationDbContext();
        }
        [Authorize]

        public ActionResult Index()
        {

            if (User.IsInRole("Admins") || User.IsInRole("Teachers") ){ 
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      PhoneNumber = user.PhoneNumber,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Course = user.Course,
                                      Course2 = user.Course2,
                                      Course3 = user.Course3,
                                      Course4 = user.Course4,
                                      Course5 = user.Course5,


                                      RoleNames = (from userRole in user.Roles
                                                   join role in db.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      PhoneNumber = p.PhoneNumber,
                                      Email = p.Email,
                                      Course = p.Course,
                                      Course2 = p.Course2,
                                      Course3 = p.Course3,
                                      Course4 = p.Course4,
                                      Course5 = p.Course5,

                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usersWithRoles);
            }
            else
            {
                return View("Error");
            }
        }
        

        // GET: Account/Details/5
        public ActionResult Details(string id)
        {

            if (User.IsInRole("Admins"))
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();  
                }

                return View(user);
            }

            else
            {
                return View("Error");
            }

            
        }



        // GET: Account/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Admins"))
            {
                return View(user);
            }
            else
            {
                return View("Error");

            }
        }


        public ActionResult Calendar()
        {
            if (User.IsInRole("Students"))
            {
                var usersWithRoles = (from user in db.Users
                                      select new
                                      {
                                          UserId = user.Id,
                                          PhoneNumber = user.PhoneNumber,
                                          Username = user.UserName,
                                          Email = user.Email,
                                          Course = user.Course,
                                          Course2 = user.Course2,
                                          Course3 = user.Course3,
                                          Course4 = user.Course4,
                                          Course5 = user.Course5,


                                          RoleNames = (from userRole in user.Roles
                                                       join role in db.Roles on userRole.RoleId
                                                       equals role.Id
                                                       select role.Name).ToList()
                                      }).ToList().Select(p => new Users_in_Role_ViewModel()

                                      {
                                          UserId = p.UserId,
                                          Username = p.Username,
                                          PhoneNumber = p.PhoneNumber,
                                          Email = p.Email,
                                          Course = p.Course,
                                          Course2 = p.Course2,
                                          Course3 = p.Course3,
                                          Course4 = p.Course4,
                                          Course5 = p.Course5,

                                          Role = string.Join(",", p.RoleNames)
                                      });


                return View(usersWithRoles);
            }

            else
            {
                return View("Error");
            }
            

        }


        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,PhoneNumber,Course,Course2,Course3,Course4,Course5")] ApplicationUser user)
        {
            if (User.IsInRole("Admins"))
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var existingUser = db.Users.Single(u => u.Id == user.Id);
                    existingUser.UserName = user.UserName;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;


                    existingUser.Course = user.Course;
                    existingUser.Course2 = user.Course2;
                    existingUser.Course3 = user.Course3;
                    existingUser.Course4 = user.Course4;
                    existingUser.Course5 = user.Course5;

                    // etc.
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View(user);
            }

            else
            {
                return View("Error");

            }
        }



        // GET: Account/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admins"))
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(user);
            }
            else
            {
                return View("Error");

            }
        }
        

        
        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplicationUser myUser)
        {
            // TODO: Add delete logic here
            ApplicationUser user = db.Users.Find(myUser.Id);

            if (User.IsInRole("Admins"))
            {

                db.Users.Remove(user);
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