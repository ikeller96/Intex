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
    public class AssaysController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Assays
        public ActionResult Index()
        {
            var assay = db.Assay.Include(a => a.WorkOrders);
            return View(assay.ToList());
        }

        // GET: Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assay.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            return View(assays);
        }

        // GET: Assays/Create
        public ActionResult Create()
        {
            ViewBag.WorkOrderID = new SelectList(db.WorkOrder, "WorkOrderID", "OrderRushed");
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssayID,WorkOrderID,AssayStatus,AssayTypeID")] Assays assays)
        {
            if (ModelState.IsValid)
            {
                db.Assay.Add(assays);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkOrderID = new SelectList(db.WorkOrder, "WorkOrderID", "OrderRushed", assays.WorkOrderID);
            return View(assays);
        }

        // GET: Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assay.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkOrderID = new SelectList(db.WorkOrder, "WorkOrderID", "OrderRushed", assays.WorkOrderID);
            return View(assays);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssayID,WorkOrderID,AssayStatus,AssayTypeID")] Assays assays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkOrderID = new SelectList(db.WorkOrder, "WorkOrderID", "OrderRushed", assays.WorkOrderID);
            return View(assays);
        }

        // GET: Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assay.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            return View(assays);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assays assays = db.Assay.Find(id);
            db.Assay.Remove(assays);
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
