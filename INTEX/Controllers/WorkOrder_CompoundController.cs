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
    public class WorkOrder_CompoundController : Controller
    {
        private Northwest_LabsContext db = new Northwest_LabsContext();

        //see all work order compounds
        // GET: WorkOrder_Compound
        public ActionResult Index()
        {
            return View(db.WorkOrder_Compound.ToList());
        }

        //see the instance details of a work order compound
        // GET: WorkOrder_Compound/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder_Compound workOrder_Compound = db.WorkOrder_Compound.Find(id);
            if (workOrder_Compound == null)
            {
                return HttpNotFound();
            }
            return View(workOrder_Compound);
        }

        //create a new work order compound
        // GET: WorkOrder_Compound/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOrder_Compound/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LTNumber,SequenceCode,Amount")] WorkOrder_Compound workOrder_Compound)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrder_Compound.Add(workOrder_Compound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workOrder_Compound);
        }

        //Edit the work order compound
        // GET: WorkOrder_Compound/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder_Compound workOrder_Compound = db.WorkOrder_Compound.Find(id);
            if (workOrder_Compound == null)
            {
                return HttpNotFound();
            }
            return View(workOrder_Compound);
        }

        // POST: WorkOrder_Compound/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LTNumber,SequenceCode,Amount")] WorkOrder_Compound workOrder_Compound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder_Compound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder_Compound);
        }

        //delete the work order compound
        // GET: WorkOrder_Compound/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder_Compound workOrder_Compound = db.WorkOrder_Compound.Find(id);
            if (workOrder_Compound == null)
            {
                return HttpNotFound();
            }
            return View(workOrder_Compound);
        }

        // POST: WorkOrder_Compound/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder_Compound workOrder_Compound = db.WorkOrder_Compound.Find(id);
            db.WorkOrder_Compound.Remove(workOrder_Compound);
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
