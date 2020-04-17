using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinancePlan.Models;

namespace FinancePlan.Controllers
{
    public class UsersController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.tbUsers.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsers tbUsers = db.tbUsers.Find(id);
            if (tbUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbUsers);
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
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,RegistrationDate")] tbUsers tbUsers)
        {
            if (ModelState.IsValid)
            {
                db.tbUsers.Add(tbUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbUsers);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsers tbUsers = db.tbUsers.Find(id);
            if (tbUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbUsers);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,RegistrationDate")] tbUsers tbUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbUsers);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsers tbUsers = db.tbUsers.Find(id);
            if (tbUsers == null)
            {
                return HttpNotFound();
            }
            return View(tbUsers);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsers tbUsers = db.tbUsers.Find(id);
            db.tbUsers.Remove(tbUsers);
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
