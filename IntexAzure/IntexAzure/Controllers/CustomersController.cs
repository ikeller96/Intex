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
    public class CustomersController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customer = db.Customer.Include(c => c.Employees);
            return View(customer.ToList());
        }

        public ActionResult ViewWorkOrders(int custID, string custName)
        {
            IEnumerable<CustomerWorkOrders> WorkOrderResults = db.Database.SqlQuery<CustomerWorkOrders>(
                "SELECT  CustID, OrderDueDate, OrderRushed, OrderStatus, OrderCreationDate, OrderDiscounts, WorkOrderID " +
                "FROM WorkOrders " +
                "WHERE CustID = " + custID
                );


            ViewBag.CustomerName = custName;
            return View(WorkOrderResults);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customer.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustID,CustName,CustAddress1,CustAddress2,CustCity,CustState,CustZip,CustEmail,CustPhone,CustPaymentInfo,EmpID,UserName,Password")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName", customers.EmpID);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customer.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName", customers.EmpID);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustID,CustName,CustAddress1,CustAddress2,CustCity,CustState,CustZip,CustEmail,CustPhone,CustPaymentInfo,EmpID,UserName,Password")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName", customers.EmpID);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customer.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customer.Find(id);
            db.Customer.Remove(customers);
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
