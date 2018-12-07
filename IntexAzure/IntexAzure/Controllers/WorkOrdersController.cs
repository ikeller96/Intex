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
        public ActionResult Index(int? CustID)
        {
            var workOrder = from wo in db.WorkOrder.Include(w => w.Customers) select wo;
            

            if (CustID != null)
            {
                workOrder = workOrder.Where(wo => wo.CustID == CustID);
            }
            
            return View(workOrder.ToList());
        }

        
        public ActionResult EmailUpdate(string CustName, int WorkOrderID, string OrderStatus, decimal CompletedTests, decimal IncompleteTests, decimal PercentComplete, string CustEmail, string EmpName)
        {
            //this is good stuff right here
            Gmailer.GmailUsername = "noreply.northwestlabs@gmail.com";
            Gmailer.GmailPassword = "intexrocks";

            Gmailer mailer = new Gmailer();
            mailer.ToEmail = CustEmail;
            
            mailer.Subject = "Status Update on Work Order " + WorkOrderID;
            mailer.Body = $"Dear {CustName},<br><br>This is an update email. Your work order number {WorkOrderID} is {PercentComplete}% complete. <br>There are {IncompleteTests} more " +
                $"tests that need to be completed.<br>For further information please reach out to your employee representative {EmpName}. <br><br> Northwest Labs";
            mailer.IsHtml = true;
            mailer.Send();
            int ID = WorkOrderID;
            return RedirectToAction("Index");
        }

        public ActionResult ViewWorkOrderAssays(int workOrderID)
        {

            return RedirectToAction("Index", "Assays", new { WorkOrderID = workOrderID });
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrdersPrice WorkOrderPrice = new WorkOrdersPrice();
            WorkOrderPrice.WorkOrder = db.WorkOrder.Find(id);

            // bring in pricing information
            var specifictests = from st in db.SpecificTest select st;
            specifictests = specifictests.Where(st => st.Assays.WorkOrderID == id);

            // get values of stuff
            WorkOrderPrice.WorkOrderPrice = specifictests.Sum(st => st.TestType.testTypeCost).GetValueOrDefault();
            WorkOrderPrice.CompleteTests = specifictests.Count(st => st.testStatus == "Complete");
            WorkOrderPrice.BackLogTests = specifictests.Count(st => st.testStatus == "BackLog");
            WorkOrderPrice.InProgressTests = specifictests.Count(st => st.testStatus == "In Progress");

            decimal totalTests = (WorkOrderPrice.CompleteTests.GetValueOrDefault() + WorkOrderPrice.BackLogTests.GetValueOrDefault() + WorkOrderPrice.InProgressTests.GetValueOrDefault());
            decimal percentComplete;
                //get decent formatting for display
            if (totalTests == 0)
            {
                 percentComplete = 0;
            }
            else
            {
                percentComplete = (WorkOrderPrice.CompleteTests.GetValueOrDefault() / (WorkOrderPrice.CompleteTests.GetValueOrDefault() + WorkOrderPrice.BackLogTests.GetValueOrDefault() + WorkOrderPrice.InProgressTests.GetValueOrDefault())) * 100;

            }
            var sPercentComplete = String.Format("{0:N0}", percentComplete);
            ViewBag.PercentComplete = sPercentComplete;


            //in case the work order price is null then reset it to 0
            /*if (WorkOrderPrice.WorkOrderPrice == null)
            {
                WorkOrderPrice.WorkOrderPrice = 0;
            }*/
            if (WorkOrderPrice == null)
            {
                return HttpNotFound();
            }
            return View(WorkOrderPrice);
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
                workOrders.OrderCreationDate = DateTime.Now;
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
