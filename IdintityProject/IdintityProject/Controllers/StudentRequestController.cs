using IdintityProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdintityProject.Controllers
{
    public class StudentRequestController : Controller
    {
        // GET: StudentRequest
        ApplicationDbContext db;


        public StudentRequestController() {

            db = new ApplicationDbContext();

        }

        // Create Request GET
        public ActionResult Index()
        {

           
                return View();
            
            
        }


        // Create Request POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(StudentRequest req)
        {
            
                if (ModelState.IsValid)
                {
                    db.StudentRequest.Add(req);
                    await db.SaveChangesAsync();
                    return RedirectToAction("StudentReq");

                }



                return View();
            


        }


        public ActionResult ApprovalRequest() {

            if (User.IsInRole("Admins"))
            {
                return View(db.StudentRequest.ToList());
            }

            else
            {
                return RedirectToAction("Index");
            }
            

           
        }

        public ActionResult StudentReq()
        {
            var name = User.Identity.GetUserName();
            var myRequestsList = db.StudentRequest.Where(x=>x.UserNameRequest.Equals(name)).ToList();

            return View(myRequestsList);

        }



        // GET: StudentRequest/Ignore/5
        public ActionResult Status(int Id)
        {
            
                var req = db.StudentRequest.Find(Id);
                if (req == null)
                {
                    return HttpNotFound();
                }

            var list = new List<string>{"Approve","Ignore"};
            ViewBag.list = list;
            return View(req);
            
        }

        // POST: Grades/Ignore/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status([Bind(Include = "Id,UserNameRequest,EmailRequest,SubjectName,messageRequest,RequestStatus")] StudentRequest theirRequest)
        {

            // TODO: Add delete logic here

            if (ModelState.IsValid)
            {
                db.Entry(theirRequest).State = EntityState.Modified;


                db.Entry(theirRequest).Property("UserNameRequest").IsModified = true;
                db.Entry(theirRequest).Property("EmailRequest").IsModified = true;
                db.Entry(theirRequest).Property("SubjectName").IsModified = true;
                db.Entry(theirRequest).Property("messageRequest").IsModified = true;
                db.Entry(theirRequest).Property("RequestStatus").IsModified = true;

                db.SaveChanges();
                return RedirectToAction("ApprovalRequest");
            }

            return View(theirRequest);




        }



        // GET: Grades/Delete/5
        public ActionResult Delete(int id)
        {
           
                var req = db.StudentRequest.Find(id);
                if (req == null)
                {
                    return HttpNotFound();
                }

                return View(req);
            
        }

        // POST: Grades/Delete/5
        [HttpPost]
        public ActionResult Delete(StudentRequest Req)
        {


            // TODO: Add delete logic here
                StudentRequest requests = db.StudentRequest.Find(Req.Id);
                db.StudentRequest.Remove(requests);
                db.SaveChanges();
                return RedirectToAction("ApprovalRequest");
           


            
        }

    }
}