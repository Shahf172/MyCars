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
    public class AddModelDetailsController : Controller
    {
        private CarsEntities db = new CarsEntities();

        // GET: AddModelDetails
        public ActionResult Index()
        {
            return View(db.ModelDetails.ToList());
        }

        // GET: AddModelDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelDetail modelDetail = db.ModelDetails.Find(id);
            if (modelDetail == null)
            {
                return HttpNotFound();
            }
            return View(modelDetail);
        }

        // GET: AddModelDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddModelDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ModelNumber,ModelName,ModelYear")] ModelDetail modelDetail)
        {
            if (ModelState.IsValid)
            {
                db.ModelDetails.Add(modelDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelDetail);
        }

        // GET: AddModelDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelDetail modelDetail = db.ModelDetails.Find(id);
            if (modelDetail == null)
            {
                return HttpNotFound();
            }
            return View(modelDetail);
        }

        // POST: AddModelDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ModelNumber,ModelName,ModelYear")] ModelDetail modelDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelDetail);
        }

        // GET: AddModelDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelDetail modelDetail = db.ModelDetails.Find(id);
            if (modelDetail == null)
            {
                return HttpNotFound();
            }
            return View(modelDetail);
        }

        // POST: AddModelDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelDetail modelDetail = db.ModelDetails.Find(id);
            db.ModelDetails.Remove(modelDetail);
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
