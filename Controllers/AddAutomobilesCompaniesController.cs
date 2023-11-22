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
    public class AddAutomobilesCompaniesController : Controller
    {
        private CarsEntities db = new CarsEntities();

        // GET: AddAutomobilesCompanies
        public ActionResult Index()
        {
            return View(db.AutomobilesCompanies.ToList());
        }

        // GET: AddAutomobilesCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomobilesCompany automobilesCompany = db.AutomobilesCompanies.Find(id);
            if (automobilesCompany == null)
            {
                return HttpNotFound();
            }
            return View(automobilesCompany);
        }

        // GET: AddAutomobilesCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddAutomobilesCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] AutomobilesCompany automobilesCompany)
        {
            if (ModelState.IsValid)
            {
                db.AutomobilesCompanies.Add(automobilesCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(automobilesCompany);
        }

        // GET: AddAutomobilesCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomobilesCompany automobilesCompany = db.AutomobilesCompanies.Find(id);
            if (automobilesCompany == null)
            {
                return HttpNotFound();
            }
            return View(automobilesCompany);
        }

        // POST: AddAutomobilesCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] AutomobilesCompany automobilesCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobilesCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automobilesCompany);
        }

        // GET: AddAutomobilesCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutomobilesCompany automobilesCompany = db.AutomobilesCompanies.Find(id);
            if (automobilesCompany == null)
            {
                return HttpNotFound();
            }
            return View(automobilesCompany);
        }

        // POST: AddAutomobilesCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutomobilesCompany automobilesCompany = db.AutomobilesCompanies.Find(id);
            db.AutomobilesCompanies.Remove(automobilesCompany);
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
