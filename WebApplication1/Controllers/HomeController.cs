using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentContext db;
        public HomeController()
        {
            db = new StudentContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        //Show database Details
        public ActionResult StudentDetail()
        {
            var data=   db.Students.ToList();
            return View(data);
        }
        
        public ActionResult AddStudent()
        {
           
            return View();
        }
        //Add and insert Recoed in Student Table
        //For Security
        [ValidateAntiForgeryToken]
        //End Security
        [HttpPost]

        public ActionResult AddStudent(Student data)
        {
            if(data.Id==0)
            { 
            db.Students.Add(data);
            db.SaveChanges();
            }
            else
            {
                var record = db.Students.SingleOrDefault(m => m.Id == data.Id);
                record.Id = data.Id;
                record.FirstName = data.FirstName;
                record.LastName = data.LastName;
                record.Dob = data.Dob;
                db.SaveChanges();
            }
            return RedirectToAction("StudentDetail");
        }
        //Edit
        public ActionResult EditStudent(int id)
        {
            var data = db.Students.SingleOrDefault(m => m.Id==id);
            return View("AddStudent",data);
        }
        //Delete
        public ActionResult DeleteStudent(int id)
        {
            var data = db.Students.SingleOrDefault(m => m.Id == id);
            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("StudentDetail");
        }


    }
}