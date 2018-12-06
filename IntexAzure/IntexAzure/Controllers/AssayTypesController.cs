using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntexAzure.DAL;
using IntexAzure.Models;

namespace IntexAzure.Controllers
{
    public class AssayTypesController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: AssayTypes
        public ActionResult Index()
        {
            return View(db.AssayType.ToList());
        }

        // GET: AssayTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTypes assayTypes = db.AssayType.Find(id);
            if (assayTypes == null)
            {
                return HttpNotFound();
            }
            return View(assayTypes);
        }

        // GET: AssayTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssayTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssayTypeID,AssayTypeDescription,AssayTypeTime")] AssayTypes assayTypes)
        {
            if (ModelState.IsValid)
            {
                db.AssayType.Add(assayTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assayTypes);
        }

        // GET: AssayTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTypes assayTypes = db.AssayType.Find(id);
            if (assayTypes == null)
            {
                return HttpNotFound();
            }
            return View(assayTypes);
        }

        // POST: AssayTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssayTypeID,AssayTypeDescription,AssayTypeTime")] AssayTypes assayTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assayTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assayTypes);
        }

        // GET: AssayTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssayTypes assayTypes = db.AssayType.Find(id);
            if (assayTypes == null)
            {
                return HttpNotFound();
            }
            return View(assayTypes);
        }

        // POST: AssayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssayTypes assayTypes = db.AssayType.Find(id);
            db.AssayType.Remove(assayTypes);
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
