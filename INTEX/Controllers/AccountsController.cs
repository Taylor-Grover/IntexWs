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
    public class AccountsController : Controller
    {
        private static bool login = false;
        private Northwest_LabsContext db = new Northwest_LabsContext();

        // GET: Accounts
        public ActionResult Index()
        {
            
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFirstName");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,AccountBalance,NumberofOrders,ClientStartDate,ClientID,SalesAgentID,Username,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFirstName", account.ClientID);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFirstName", account.ClientID);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,AccountBalance,NumberofOrders,ClientStartDate,ClientID,SalesAgentID,Username,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFirstName", account.ClientID);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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

        public ActionResult displayAccount(/*int WOID,*/ int CID)
        {

            if (login == true)
            {
                Account myAccount = new Account();
                foreach(var item in db.Accounts)
                {
                    if(item.ClientID == CID)
                    {
                        myAccount = item;
                    }
                }
                int numWorkOrders = 0;
                foreach(var item in db.WorkOrders)
                {
                    if(item.ClientID == CID)
                    {
                        numWorkOrders++;
                    }
                }


                ClientAccount clientaccount = new ClientAccount();
                Client currClient = db.Clients.Find(CID);
                clientaccount.AccountID = myAccount.AccountID;
                clientaccount.AccountBalance = myAccount.AccountBalance;
                clientaccount.ClientAddress = currClient.ClientAddress;
                clientaccount.ClientEmail = currClient.ClientEmail;
                clientaccount.CompanyName = currClient.CompanyName;
                clientaccount.ClientFirstName = currClient.ClientFirstName;
                clientaccount.ClientLastName = currClient.ClientLastName;
                clientaccount.ClientID = currClient.ClientID;
                clientaccount.ClientPhone = currClient.ClientPhone;
                clientaccount.NumberofOrders = numWorkOrders;
                clientaccount.ClientStartDate = myAccount.ClientStartDate;
                return View(clientaccount);
            }
            else
            {
                ViewBag.Error = "Enter a valid username and password";
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool isFound = false;

            Client currClient = new Client();
            foreach(var item in db.Clients)
            {
                if(item.ClientEmail == username)
                {
                    currClient = item;
                    isFound = true;
                }

            }
            if (isFound == false)
            {
                return View();
            }


            if(username != null && password != null)
            {
                login = true;
               
                return RedirectToAction("displayAccount","Accounts", new { CID = currClient.ClientID });
            }
            else
            { 
                return View();
            }
        }

        [HttpGet]
        public ActionResult newAccount(Client currClient)
        {
            return View();
        }
        [HttpPost]
        public ActionResult newAccount([Bind(Include = "Username,Password")] ClientAccount clientaccount, Client currClient)
        {
            Random randomNum = new Random();
            int newAccountID = randomNum.Next(100000, 999999);
            foreach (var item in db.Accounts)
            {
                if (item.AccountID == newAccountID)
                {
                    newAccountID = randomNum.Next(100000, 999999);
                }
            }

            Account newAccount = new Account();
            newAccount.AccountID = newAccountID;
            newAccount.AccountBalance = 0;
            newAccount.ClientID = currClient.ClientID;
            newAccount.ClientStartDate = DateTime.Today;
            newAccount.NumberofOrders = 0;
            db.Accounts.Add(newAccount);
            db.SaveChanges();

            return RedirectToAction("Login", "Accounts");
        }

    }
}
