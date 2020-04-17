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
    public class SpendingsController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Spendings
        public ActionResult Index()
        {
            var tbSpending = db.tbSpending.Include(t => t.tbUsers);
            return View(tbSpending.ToList());
        }

        // GET: Spendings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSpending tbSpending = db.tbSpending.Find(id);
            if (tbSpending == null)
            {
                return HttpNotFound();
            }
            return View(tbSpending);
        }

        // GET: Spendings/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Spendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpendingId,UserId,MethodId,Amount,Date,CurrencyId")] tbSpending tbSpending)
        {
            if (ModelState.IsValid)
            {
                db.tbSpending.Add(tbSpending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbSpending.UserId);
            return View(tbSpending);
        }

        // GET: Spendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSpending tbSpending = db.tbSpending.Find(id);
            if (tbSpending == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbSpending.UserId);
            return View(tbSpending);
        }

        // POST: Spendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpendingId,UserId,MethodId,Amount,Date,CurrencyId")] tbSpending tbSpending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbSpending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbSpending.UserId);
            return View(tbSpending);
        }

        // GET: Spendings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSpending tbSpending = db.tbSpending.Find(id);
            if (tbSpending == null)
            {
                return HttpNotFound();
            }
            return View(tbSpending);
        }

        // POST: Spendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSpending tbSpending = db.tbSpending.Find(id);
            db.tbSpending.Remove(tbSpending);
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
