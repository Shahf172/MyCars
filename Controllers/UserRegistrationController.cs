using MyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MyCars.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        [HttpGet]
        public ActionResult AddUser(int ID=0)
        {
            CarsEntities db = new CarsEntities();
            Customer customervm = new Customer();


            return View(customervm);
        }
        [HttpPost]
        public ActionResult AddUser(Customer customervm)
        {
            CarsEntities db = new CarsEntities();
            {
                db.Customers.Add(customervm);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registered Successfully";
            return View("AddUser", new Customer());
        }
    }
}