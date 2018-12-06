using INTEX.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INTEX.Models;

//Authors: The Magical Designer: Rhett Burton, The Wise Problem Solver: Isaac White, The Beast at Coding: Taylor Grover, the SQL Guy and Assistant to the Beast: Justin Schwendiman
//Program Description: This is a prototype website that allows Northwest Labs to perform many of the functions needed to be successful. As this is just a prototype, not all functions are present, but the database makes it possible to implement more functions
namespace INTEX.Controllers
{
    public class HomeController : Controller
    {
        //This variable allows a user to login to their accounts
        private static bool login = false;
        private Northwest_LabsContext db = new Northwest_LabsContext();

        //This list of assays allows the program to keep track of the assays a user orders in a single workorder. This is displayed in the summary view in this controller.
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

        //This is the action method that receives a Work Order Number parameter that continues to get passed throughout the program. This particular method shows the user all of the possible assays they can choose from
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

        //This action method allows a client to create an account via the form provided.
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

        //This action method allows the 
        public ActionResult ClientOrders(int CID)
        {
            ViewBag.CID = CID;
            return View(db.WorkOrders.ToList());
        }

        //This takes the user to the summary view, receiving parameters of WorkOrderNumber, ClientID, and AssayID. These allow the program to access the correct assays that should be displayed in the view
        public ActionResult Summary(int WOID, int CID, int AID)
        {
            //The following sequel query gathers every assay on a given work order
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

        //This action method takes the user to the confirmation view. The method receives the ClientID and thanks the user for making an order.
        public ActionResult Confirmation( int CID)
        {
            misAssays.Clear();

            ViewBag.CID = CID;
            misAssays.Clear();
            return View();
        }

        //This is the action method to display the estimated price for every assay so that a user can get an idea of pricing. This can be developed into a more in depth 'get a quote' function
        public ActionResult Quote()
        {
          IEnumerable<Quote> myQuotes = db.Database.SqlQuery<Quote>(
         "SELECT Query1.AssayID, Query1.AssayDescription, Query1.AssayProtocol, (Cost1 + TotCost) AS AssayCost FROM (SELECT A.AssayID, A.AssayDescription, A.AssayProtocol, (SUM(BaseCost)+((SELECT AVG(Lab_Employee.HourlyWage) FROM Lab_Employee)*CompletionEstimate)) AS Cost1 From Assay A INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON ATe.TestID = T.TestID GROUP BY A.AssayID, A.AssayDescription, A.CompletionEstimate, A.AssayProtocol) AS Query1, (SELECT AssayID, SUM(TM.MatAmount*Cost) AS TotCost FROM Material M INNER JOIN Test_Material TM ON M.MaterialID = TM.MaterialID INNER JOIN Test T ON TM.TestID = T.TestID INNER JOIN Assay_Test Ate ON T.TestID = Ate.TestID GROUP BY Ate.AssayID) AS Query2 WHERE Query1.AssayID = Query2.AssayID");

            return View(myQuotes);
        }


        //This allows a user already logged in to see a quote estimate without having to go back through the home page. It receives a client id parameter that allows the client to be maintained
        public ActionResult QuoteA(int? CID)
        {
            IEnumerable<Quote> myQuotes = db.Database.SqlQuery<Quote>(
           "SELECT Query1.AssayID, Query1.AssayDescription, Query1.AssayProtocol, (Cost1 + TotCost) AS AssayCost FROM (SELECT A.AssayID, A.AssayDescription, A.AssayProtocol, (SUM(BaseCost)+((SELECT AVG(Lab_Employee.HourlyWage) FROM Lab_Employee)*CompletionEstimate)) AS Cost1 From Assay A INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON ATe.TestID = T.TestID GROUP BY A.AssayID, A.AssayDescription, A.CompletionEstimate, A.AssayProtocol) AS Query1, (SELECT AssayID, SUM(TM.MatAmount*Cost) AS TotCost FROM Material M INNER JOIN Test_Material TM ON M.MaterialID = TM.MaterialID INNER JOIN Test T ON TM.TestID = T.TestID INNER JOIN Assay_Test Ate ON T.TestID = Ate.TestID GROUP BY Ate.AssayID) AS Query2 WHERE Query1.AssayID = Query2.AssayID");
            ViewBag.CID = CID;
            return View(myQuotes);
        }

        //This action method displays every assay avaible by Northwest Labs. It includes some information about the assay so the user can see what Northwest Labs has to offer
        public ActionResult Catalog()
        {

            //This SQL query essentially creates a list of Catalog objects. It includes all the information needed for the user to see, including info about each test procedure that makes up an assay. If the project is approved, this will need further work
            IEnumerable<Catalog> companyCatalog = db.Database.SqlQuery<Catalog>(
           "SELECT A.AssayID, AssayDescription, AssayProtocol, CompletionEstimate, IsRequired, Conditional, TestName, BaseCost, P.Description " +
           "FROM Assay A " +
           "INNER JOIN Assay_Test ATe ON A.AssayID = ATe.AssayID INNER JOIN Test T ON Ate.TestID = T.TestID INNER JOIN Test_Procedures TP ON T.TestID = TP.TestID " +
           "INNER JOIN Procedures P ON TP.ProdedureID = P.ProdedureID " +
           "ORDER BY A.AssayID");
            return View(companyCatalog);

        }

        //Allows for login by all Lab Employees in Singapore. This feature is not fully functional
       [HttpGet]
       public ActionResult EmployeeLogin()
        {
            return View("LoginSing");
        } 

        [HttpPost]
        public ActionResult EmployeeLogin(string username, string password)
        {
            return RedirectToAction("Index", "WorkOrders");
        }

        //Allows for login by all Employees. This feature is not fully functional
        [HttpGet]
        public ActionResult EmployeeLogin1()
        {
            return View("LoginSeat");
        }

        [HttpPost]
        public ActionResult EmployeeLogin1(string username, string password)
        {
            return RedirectToAction("Index", "Clients");
        }

        //Allows for login by Seattle Employees. This feature is not fully functional
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

        //Allows for login by Singapore Employees. This feature is not fully functional
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