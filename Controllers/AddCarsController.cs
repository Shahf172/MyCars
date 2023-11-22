using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCars.Models;

namespace MyCars.Controllers
{
    public class AddCarsController : Controller
    {
        private CarsEntities db = new CarsEntities();

        // GET: AddCars
        public ActionResult Index()
        {
            var automobiles = db.Automobiles.Include(a => a.AutomobilesCompany).Include(a => a.ModelDetail);
            return View(automobiles.ToList());
        }

        // GET: AddCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // GET: AddCars/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.AutomobilesCompanies, "ID", "Name");
            ViewBag.ModelID = new SelectList(db.ModelDetails, "ID", "ModelName");
            return View();
        }

        // POST: AddCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutomobileID,CompanyID,Status,ModelID,Price")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Automobiles.Add(automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.AutomobilesCompanies, "ID", "Name", automobile.CompanyID);
            ViewBag.ModelID = new SelectList(db.ModelDetails, "ID", "ModelName", automobile.ModelID);
            return View(automobile);
        }

        // GET: AddCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.AutomobilesCompanies, "ID", "Name", automobile.CompanyID);
            ViewBag.ModelID = new SelectList(db.ModelDetails, "ID", "ModelName", automobile.ModelID);
            return View(automobile);
        }

        // POST: AddCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutomobileID,CompanyID,Status,ModelID,Price")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.AutomobilesCompanies, "ID", "Name", automobile.CompanyID);
            ViewBag.ModelID = new SelectList(db.ModelDetails, "ID", "ModelName", automobile.ModelID);
            return View(automobile);
        }

        // GET: AddCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // POST: AddCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automobile automobile = db.Automobiles.Find(id);
            db.Automobiles.Remove(automobile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
