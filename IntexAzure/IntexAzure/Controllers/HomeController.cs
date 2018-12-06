using IntexAzure.DAL;
using IntexAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IntexAzure.Controllers
{
    public class HomeController : Controller
    {
        private IntexContext db = new IntexContext();
        private static string currentUserName;
        private static string currentPassword;

        public ActionResult Index()
        {
            //test
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["UserName"].ToString();
            String password = form["Password"].ToString();

            var LoginID =
                    db.Database.SqlQuery<Customers>(
                "Select * " +
                "FROM Customers " +
                "WHERE UserName = '" + username + "' AND " +
                "Password = '" + password + "'");

            if (LoginID.Count() > 0)
            {
                //this is how customers log in
                if (string.Equals(username, LoginID.First().UserName) && (string.Equals(password, LoginID.First().Password)))
                {
                    FormsAuthentication.SetAuthCookie(username, rememberMe);
                    currentUserName = username;
                    currentPassword = password;

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    return View();
                }

            }
            //this is how employees log in
            else if (string.Equals(username, "admin") && (string.Equals(password, "admin")))  
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                currentUserName = username;
                currentPassword = password;

                return RedirectToAction("Index", "Home");
            }

            else
            {
                return View();
            }

        }


        public ActionResult SignUp()
        {
            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName");
            ViewBag.Employees = db.Employee.ToList();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "CustID,CustName,CustAddress1,CustAddress2,CustCity,CustState,CustZip,CustEmail,CustPhone,CustPaymentInfo,EmpID,UserName,Password")] Customers customers)
        {
            if (ModelState.IsValid)
            {

                var currentUser =
                db.Database.SqlQuery<Customers>(
            "Select * " +
            "FROM Customers " +
            "WHERE UserName = '" + customers.UserName + "' AND " +
            "Password = '" + customers.Password + "'");

                if (currentUser.Count() > 0)
                {
                    //FormsAuthentication.SetAuthCookie(username, rememberMe);
                    ViewBag.Message = "That username and password are already being used.";
                    ViewBag.Employees = db.Employee.ToList();
                    return View("SignUp"); //I should inform them that the username or password is already taken.

                }

                db.Customer.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employee, "EmpID", "EmpName", customers.EmpID);
            ViewBag.Employees = db.Employee.ToList();
            return View(customers);
        }

        [Authorize]
        public ActionResult MyWorkOrders()
        {
          
            var currentUserID =
                 db.Database.SqlQuery<Customers>(
                    "Select * " +
                    "FROM Customers " +
                    "WHERE UserName = '" + currentUserName + "' AND " +
                    "Password = '" + currentPassword + "'");

            if (currentUserID.Count() > 0)
            {

                int test = currentUserID.First().CustID;

                var myWorkOrders =
                     db.Database.SqlQuery<WorkOrders>(
                        "Select * " +
                        "FROM WorkOrders " +
                        "WHERE CustID = " + test);
                
                if (myWorkOrders.Count() > 0)
                {
                return View(myWorkOrders.ToList());
                }
                else
                {
                    return View("Index");
                }
            }

            else
            {
                return View("Login");
            }
        }


        public ActionResult WorkOrderAssays(int id)
        {
            var currentAssays =
                 db.Database.SqlQuery<Assays>(
                    "Select * " +
                    "FROM Assays " +
                    "WHERE WorkOrderID = " + id);


            return View(currentAssays.ToList());
        }

        public ActionResult AssayTests(int id)
        {
            var currentTests =
                 db.Database.SqlQuery<SpecificTests>(
                    "Select * " +
                    "FROM SpecificTests " +
                    "WHERE AssayID = " + id);


            return View(currentTests.ToList());
        }

    }
}