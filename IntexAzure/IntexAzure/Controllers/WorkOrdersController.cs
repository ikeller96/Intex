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
    public class WorkOrdersController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: WorkOrders
        public ActionResult Index(string CustName)
        {
            var workOrder = from wo in db.WorkOrder.Include(w => w.Customers) select wo;
            var test = db.WorkOrder.Include(w => w.Customers);
            if(!String.IsNullOrEmpty(CustName))
            {
                workOrder = workOrder.Where(wo => wo.Customers.CustName.Equals(CustName));
            }
            return View(workOrder.ToList());
        }

        public ActionResult EmailUpdate(string email, string name, string status, int workorderid, int testnum)
        {

            Gmailer.GmailUsername = "joshuasperry@gmail.com";
            Gmailer.GmailPassword = "Brighton@14";

            Gmailer mailer = new Gmailer();
            mailer.ToEmail = email;
            mailer.Subject = "suck it again";
            mailer.Body = $"Dear {name},<br><br>This is an update email. Your work order {workorderid}'s status is currently {status} and testnum is {testnum}.<br><br> From,<br><br>Your MOM";
            mailer.IsHtml = true;
            mailer.Send();
            return RedirectToAction("Index");
        }

        public ActionResult ViewWorkOrderAssays(int WorkOrderID)
        {
            IEnumerable<Assays> AssaysResults = db.Database.SqlQuery<Assays>(
               "SELECT * FROM Assays WHERE WorkOrderID =" + WorkOrderID);
            return View("../Assays/Index", AssaysResults);
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.WorkOrder.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            return View(workOrders);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "CustName");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderID,OrderDueDate,OrderRushed,OrderStatus,OrderCreationDate,OrderDiscounts,CustID")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrder.Add(workOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Customer, "CustID", "CustName", workOrders.CustID);
            return View(workOrders);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.WorkOrder.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "CustName", workOrders.CustID);
            return View(workOrders);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderID,OrderDueDate,OrderRushed,OrderStatus,OrderCreationDate,OrderDiscounts,CustID")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Customer, "CustID", "CustName", workOrders.CustID);
            return View(workOrders);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.WorkOrder.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            return View(workOrders);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrders workOrders = db.WorkOrder.Find(id);
            db.WorkOrder.Remove(workOrders);
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
