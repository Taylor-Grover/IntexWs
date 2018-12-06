using INTEX.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INTEX.Models;


namespace INTEX.Controllers
{
    public class HomeController : Controller
    {
        private Northwest_LabsContext db = new Northwest_LabsContext();
        private static List<Assay> misAssays = new List<Assay>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult displayAssays(int? myWorkOrderID)
        {
            ViewBag.myWorkOrderID = myWorkOrderID;
            return View(db.Assays.ToList());
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientZip,ClientEmail,ClientPhone,SpecialCondition")] Client client)
        {
            if (ModelState.IsValid)
            {
               
                db.Clients.Add(client);
                db.SaveChanges();
                //int tempID = client.ClientID;
                //return RedirectToAction("Create", "WorkOrders", new {ClientID = tempID });
                return RedirectToAction("newAccount", "Accounts", client);
            }

            return View(client);
        }

        public ActionResult ClientOrders(int CID)
        {
            ViewBag.CID = CID;
            return View(db.WorkOrders.ToList());
        }

        public ActionResult Summary(int WOID, int CID, int AID)
        {
           
            IEnumerable<Assay> myAssays = db.Database.SqlQuery<Assay>(
               "SELECT DISTINCT Assay.AssayID, AssayDescription, AssayProtocol, CompletionEstimate " +
               "FROM Assay INNER JOIN Order_Assay_Test ON Assay.AssayID = Order_Assay_Test.AssayID " +
               "WHERE Order_Assay_Test.WorkOrderNumber = " + WOID + " AND " +
               "Order_Assay_Test.AssayID = " + AID
                );
            foreach(var item in myAssays)
            {
                misAssays.Add(item);
            }
            ViewBag.WOID = WOID;
            ViewBag.CID = CID;

            return View(misAssays);
        }

        public ActionResult Confirmation(/*int WOID,*/ int CID)
        {
            //ViewBag.WOID = WOID;
            ViewBag.CID = CID;
            return View();
        }

        public ActionResult Quote()
        {
          IEnumerable<Quote> myQuotes = db.Database.SqlQuery<Quote>(
         "SELECT A.AssayID, A.AssayDescription, A.AssayProtocol, (SUM(BaseCost)+((SELECT AVG(Lab_Employee.HourlyWage) FROM Lab_Employee)*CompletionEstimate)) AS AssayCost From Assay A INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON ATe.TestID = T.TestID GROUP BY A.AssayID, A.AssayDescription, A.CompletionEstimate, A.AssayProtocol");

            return View(myQuotes);
        }

    }
}