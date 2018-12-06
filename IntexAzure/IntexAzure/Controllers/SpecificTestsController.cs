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
    public class SpecificTestsController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: SpecificTests
        public ActionResult Index(int? AssayID)
        {
            var specifictests = from st in db.SpecificTest.Include(st => st.TestType) select st; 
            if(AssayID != null)
            {
                specifictests = specifictests.Where(st => st.AssayID == AssayID);
            }
            return View(db.SpecificTest.ToList());
        }

        // GET: SpecificTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecificTests specificTests = db.SpecificTest.Find(id);
            if (specificTests == null)
            {
                return HttpNotFound();
            }
            return View(specificTests);
        }

        // GET: SpecificTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecificTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompoundTestID,AssayID,TestTypeID,QuantitativeResults,QualitativeResults,CompoundSC,MaterialsListID")] SpecificTests specificTests)
        {
            if (ModelState.IsValid)
            {
                db.SpecificTest.Add(specificTests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specificTests);
        }

        // GET: SpecificTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecificTests specificTests = db.SpecificTest.Find(id);
            if (specificTests == null)
            {
                return HttpNotFound();
            }
            return View(specificTests);
        }

        // POST: SpecificTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompoundTestID,AssayID,TestTypeID,QuantitativeResults,QualitativeResults,CompoundSC,MaterialsListID")] SpecificTests specificTests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specificTests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specificTests);
        }

        // GET: SpecificTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecificTests specificTests = db.SpecificTest.Find(id);
            if (specificTests == null)
            {
                return HttpNotFound();
            }
            return View(specificTests);
        }

        // POST: SpecificTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecificTests specificTests = db.SpecificTest.Find(id);
            db.SpecificTest.Remove(specificTests);
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
