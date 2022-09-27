using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdintityProject.Models;

namespace IdintityProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;


        public HomeController()
        {

            db = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(UserRequestsModel userReq)
        {


            if (ModelState.IsValid)
            {
                db.UserRequestsModel.Add(userReq);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }



            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult UserRequest()
        {

            return View("UserRequest");
        }

        public ActionResult Policy()
        {


            return View();
        }



     


    }
}