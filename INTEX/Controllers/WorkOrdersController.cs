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
    public class WorkOrdersController : Controller
    {
        private Northwest_LabsContext db = new Northwest_LabsContext();

        //see all work orders
        // GET: WorkOrders
        public ActionResult Index()
        {
            return View(db.WorkOrders.ToList());
        }

        //see the details of an individual work order
        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        //create a new work order
        // GET: WorkOrders/Create
        public ActionResult Create(int ClientID)
        {
           
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderNumber,OrderDate,DueDate,ClientID,PaymentInfo,Comments,CompoundName,LTNumber,SalesAgentID")] WorkOrder workOrder, int ClientID)
        {
            workOrder.ClientID = ClientID;
            if (ModelState.IsValid)
            {
                workOrder.Complete = false;
                workOrder.OrderDate = DateTime.Now;
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                
                return RedirectToAction("displayAssays", "Home", new { myWorkOrderID = workOrder.WorkOrderNumber });
            }

            return View(workOrder);
        }

        //edit an existing work order
        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderNumber,OrderDate,DueDate,ClientID,PaymentInfo,Comments,LTNumber,SalesAgentID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                //This SQL statement adds an LTNumber to the work order
                db.Database.ExecuteSqlCommand("INSERT INTO WorkOrder_Compound (LTNumber) " +
                    "VALUES (" + workOrder.LTNumber + ")");
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }

        //delete an existing work order
        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workOrder);
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
