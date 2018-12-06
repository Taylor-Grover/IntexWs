using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class TestsController : Controller
    {
        private Northwest_LabsContext db = new Northwest_LabsContext();

        //See all tests in the database
        // GET: Tests
        public ActionResult Index()
        {
            
           
            return View(db.Tests.ToList());
        }

        //see the details of a test in the database
        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            return View();
        }

        //Add a new test to the database
        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestID,TestName,BaseCost")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        //edit the tests in the database
        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestID,TestName,BaseCost")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        //delete tests from the database
        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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


        //Show all of the tests linked to a specific assay. This will be loaded after a user selects an assay in the process of building a new work order
        public ActionResult displayTests(int id, int? myWorkOrderID)
        {
            ViewBag.workorderid = myWorkOrderID;
            ViewBag.AssayID = id;

            //this query takes an assay id (passed from the previous view) and finds all tests connected to it.
         IEnumerable<displayTests> myTests = db.Database.SqlQuery<displayTests>(
         "Select Test.TestID, Test.TestName, Test.Description, Test.BaseCost, " +
         "Assay_Test.IsRequired, Assay_Test.Conditional " +
         "FROM Test INNER JOIN Assay_Test ON " +
         "Test.TestID = Assay_Test.TestID " +
         "WHERE Assay_Test.AssayID = " + id);

            //This gives us a list of test ids related to the assay. This is passed to the view with the viewbag.
            List<int> listtest = new List<int>();
            foreach(var item in myTests)
            {
                listtest.Add(item.TestID);
            }
            ViewBag.testIDs = listtest;
            return View(myTests);
        }

        [HttpPost]
        public ActionResult displayTests(displayTests item)
        {
            return View();
        }

    }
}
