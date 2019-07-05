using InfomatrixBingo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDummyAPI.Classes;

namespace BingoApp.Controllers
{
    public class UsersController : Controller
    {
        private BingoModel db = new BingoModel();
        public String message = "mes";

        // GET: Users
        public ActionResult Index()
        {
            return View(db.UsersTBs.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTB usersTB = db.UsersTBs.Find(id);
            if (usersTB == null)
            {
                return HttpNotFound();
            }
            return View(usersTB);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,Username,Email,Password")] UsersTB usersTB)
        {
            if (ModelState.IsValid)
            {
                db.UsersTBs.Add(usersTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersTB);
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            ViewBag.Message = StaticClass.errorMessage;
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "PlayerID,Username,Email,Password")] UsersTB usersTB, String confirmPass)
        {

            if (ModelState.IsValid)
            {
                if (usersTB.Password.Equals(confirmPass))
                {
                    Session["Username"] = usersTB.Username;
                    db.UsersTBs.Add(usersTB);
                    db.SaveChanges();
                    StaticClass.errorMessage = "";
                    StaticClass.currentUser = usersTB.Username;

                    //search for userID

                    List<UsersTB> users = db.UsersTBs.ToList();
                    
                    int searchUserID = 0;

                    foreach (UsersTB user in users)
                    {
                        if (user.Email.Equals(usersTB.Email) && user.Username.Equals(usersTB.Username))
                        {
                            Debug.WriteLine("USER FOUND");

                            if (user.Password.Equals(usersTB.Password))
                            {
                                
                                searchUserID = user.PlayerID;

                            }
                        }

                        //Debug.WriteLine(user.Email + " " + user.Username + " " + user.Password);
                    }


                    AccountsTB accountsTB = new AccountsTB();
                    accountsTB.PlayerID = searchUserID;
                    accountsTB.Balance = 500;
                    db.AccountsTBs.Add(accountsTB);
                    db.SaveChanges();


                    List<AccountsTB> accounts = db.AccountsTBs.ToList();
                    foreach (AccountsTB account in accounts)
                    {
                        if (account.PlayerID == searchUserID)
                        {
                            StaticClass.balance = account.Balance;
                            StaticClass.accId = account.AccountID;
                        }
                        

                    }


                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    StaticClass.errorMessage = "ERROR: Passwords don't match...";

                    Debug.WriteLine("DEBUG!!!    " + StaticClass.errorMessage);

                    return RedirectToAction("Register", "Users");
                }
            }

            StaticClass.errorMessage = "INVALID Details Entered, Please Try again...";

            Debug.WriteLine("DEBUG!!!    " + StaticClass.errorMessage);

            return RedirectToAction("Register", "Users");

        }


        // GET: Users/Login
        public ActionResult Login()
        {
            ViewBag.Message = StaticClass.errorMessage;
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "PlayerID,Username,Email,Password")] UsersTB usersTB)
        {

            int userID = 0;

            Debug.WriteLine("OUR USER: " + usersTB.Username + " " + usersTB.Password);

            List<UsersTB> users = db.UsersTBs.ToList();

            Boolean found = false;

            foreach (UsersTB user in users)
            {
                if (user.Email.Equals(usersTB.Username) || user.Username.Equals(usersTB.Username))
                {
                    Debug.WriteLine("USER FOUND");

                    if (user.Password.Equals(usersTB.Password))
                    {
                        Debug.WriteLine("PASS FOUND");
                        found = true;
                        userID = user.PlayerID;
                        StaticClass.currentUser = usersTB.Username;

                    }
                }

                //Debug.WriteLine(user.Email + " " + user.Username + " " + user.Password);
            }

            Debug.WriteLine("USER LOGIN ID: " + userID);


            if (found == true)
            {
                StaticClass.errorMessage = "SUCCESSSSSSSS!!!!!!!!!!!!!!";
                Session["Username"] = usersTB.Username;

                Debug.WriteLine("DEBUG!!!    " + StaticClass.errorMessage);
                StaticClass.errorMessage = "";

                List<AccountsTB> accounts = db.AccountsTBs.ToList();
                foreach (AccountsTB account in accounts)
                {
                    if (account.PlayerID == userID)
                    {
                        StaticClass.balance = account.Balance;
                        StaticClass.accId = account.AccountID;

                        return RedirectToAction("Index", "Home");

                    }


                   

                }




            }
            else
            {


                StaticClass.errorMessage = "INVALID Details Entered, Please Try again...";

                Debug.WriteLine("DEBUG!!!    " + StaticClass.errorMessage);

                return RedirectToAction("Login", "Users");
            }


            return RedirectToAction("GamePage", "Game");

        }


        // GET: Users/Logout
        public ActionResult Logout()
        {
            StaticClass.currentUser = "NoUser";
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTB usersTB = db.UsersTBs.Find(id);
            if (usersTB == null)
            {
                return HttpNotFound();
            }
            return View(usersTB);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,Username,Email,Password")] UsersTB usersTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersTB);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersTB usersTB = db.UsersTBs.Find(id);
            if (usersTB == null)
            {
                return HttpNotFound();
            }
            return View(usersTB);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersTB usersTB = db.UsersTBs.Find(id);
            db.UsersTBs.Remove(usersTB);
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