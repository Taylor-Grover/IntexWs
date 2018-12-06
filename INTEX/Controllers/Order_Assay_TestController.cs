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
    public class Order_Assay_TestController : Controller
    {
        private Northwest_LabsContext db = new Northwest_LabsContext();

        // GET: Order_Assay_Test
        public ActionResult Index()
        {
            return View(db.Order_Assay_Test.ToList());
        }

        // GET: Order_Assay_Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Assay_Test order_Assay_Test = db.Order_Assay_Test.Find(id);
            if (order_Assay_Test == null)
            {
                return HttpNotFound();
            }
            return View(order_Assay_Test);
        }

        // GET: Order_Assay_Test/Create
        public ActionResult Create(int workOrderID, int AssayID)
        {
            return View();
        }

        // POST: Order_Assay_Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderNumber,AssayID,TestID,EmployeeID,IsComplete,TotalCost,ResultID")] Order_Assay_Test order_Assay_Test, int workOrderID, int AssayID)
        {
            List<int> testids = db.Database.SqlQuery<int>("SELECT TestID FROM Assay_Test WHERE Assay_Test.AssayID = " + AssayID).ToList();

            foreach (var item in testids)
            {
                Order_Assay_Test record = new Order_Assay_Test();
                record.WorkOrderNumber = workOrderID;
                record.AssayID = AssayID;
                record.TestID = item;
                db.Order_Assay_Test.Add(record);
                db.SaveChanges();
            }
            int CID = 0; 
            foreach(var item in db.WorkOrders)
            {
                if(item.WorkOrderNumber == workOrderID)
                {
                     CID = item.ClientID;
                }
            }
            Client myClient = db.Clients.Find(CID);
            return RedirectToAction("Summary", "Home", new { WOID = workOrderID, CID = myClient.ClientID, AID = AssayID });
           

            

            //return View(order_Assay_Test);
        }

        // GET: Order_Assay_Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Assay_Test order_Assay_Test = db.Order_Assay_Test.Find(id);
            if (order_Assay_Test == null)
            {
                return HttpNotFound();
            }
            return View(order_Assay_Test);
        }

        // POST: Order_Assay_Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderNumber,AssayID,TestID,EmployeeID,IsComplete,TotalCost,ResultID")] Order_Assay_Test order_Assay_Test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Assay_Test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_Assay_Test);
        }

        // GET: Order_Assay_Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Assay_Test order_Assay_Test = db.Order_Assay_Test.Find(id);
            if (order_Assay_Test == null)
            {
                return HttpNotFound();
            }
            return View(order_Assay_Test);
        }

        // POST: Order_Assay_Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Assay_Test order_Assay_Test = db.Order_Assay_Test.Find(id);
            db.Order_Assay_Test.Remove(order_Assay_Test);
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
