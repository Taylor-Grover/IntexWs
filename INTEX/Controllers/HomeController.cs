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
        public ActionResult Create([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientEmail,ClientPhone,SpecialCondition")] Client client)
        {
            if (ModelState.IsValid)
            {
               
                db.Clients.Add(client);
                db.SaveChanges();
                int tempID = client.ClientID;
                return RedirectToAction("Create", "WorkOrders", new {ClientID = tempID });
            }

            return View(client);
        }

        public ActionResult ClientOrders(int? CID)
        {
            ViewBag.CID = 44;
            return View(db.WorkOrders.ToList());
        }



    }
}