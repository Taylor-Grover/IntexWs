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
        private static bool login = false;
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
        public ActionResult Create([Bind(Include = "ClientID,CompanyName,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientZip,ClientEmail,ClientPhone,SpecialCondition")] Client client)
        {
            if (ModelState.IsValid)
            {
               
                db.Clients.Add(client);
                db.SaveChanges();

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

        public ActionResult Confirmation( int CID)
        {
            misAssays.Clear();

            ViewBag.CID = CID;
            return View();
        }

        public ActionResult Quote()
        {
          IEnumerable<Quote> myQuotes = db.Database.SqlQuery<Quote>(
         "SELECT A.AssayID, A.AssayDescription, A.AssayProtocol, (SUM(BaseCost)+((SELECT AVG(Lab_Employee.HourlyWage) FROM Lab_Employee)*CompletionEstimate)) AS AssayCost From Assay A INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON ATe.TestID = T.TestID GROUP BY A.AssayID, A.AssayDescription, A.CompletionEstimate, A.AssayProtocol");

            return View(myQuotes);
        }

        public ActionResult Catalog()
        {

            IEnumerable<Catalog> companyCatalog = db.Database.SqlQuery<Catalog>(
           "SELECT A.AssayID, AssayDescription, AssayProtocol, CompletionEstimate, IsRequired, Conditional, TestName, BaseCost, P.Description " +
           "FROM Assay A " +
           "INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON Ate.TestID = T.TestID INNER JOIN Test_Procedures TP ON T.TestID = TP.TestID " +
           "INNER JOIN Procedures P ON TP.ProdedureID = P.ProdedureID " +
           "ORDER BY A.AssayID");
            return View(companyCatalog);

        }

       [HttpGet]
       public ActionResult EmployeeLogin()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult EmployeeLogin(string username, string password)
        {
            return RedirectToAction("Index", "WorkOrders");
        }
       


        [HttpGet]
        public ActionResult LoginSeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSeat(string username, string password)
        {
            Client currClient = new Client();
            foreach (var item in db.Clients)
            {
                if (item.ClientEmail == username)
                {
                    currClient = item;
                }
            }


            if (username != null && password != null)
            {
                login = true;

                return RedirectToAction("displayAccount", "Accounts", new { CID = currClient.ClientID });
            }
            else
            {


                return View();
            }
        }


        [HttpGet]
        public ActionResult LoginSing()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSing(string username, string password)
        {
            Client currClient = new Client();
            foreach (var item in db.Clients)
            {
                if (item.ClientEmail == username)
                {
                    currClient = item;
                }
            }


            if (username != null && password != null)
            {
                login = true;

                return RedirectToAction("displayAccount", "Accounts", new { CID = currClient.ClientID });
            }
            else
            {


                return View();
            }
        }

    }
}