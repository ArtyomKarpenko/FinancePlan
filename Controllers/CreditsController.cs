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
    public class CreditsController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Credits
        public ActionResult Index()
        {
            var tbCredits = db.tbCredits.Include(t => t.tbUsers);
            return View(tbCredits.ToList());
        }

        // GET: Credits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCredits tbCredits = db.tbCredits.Find(id);
            if (tbCredits == null)
            {
                return HttpNotFound();
            }
            return View(tbCredits);
        }

        // GET: Credits/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Credits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditId,UserId,MethodId,FullAmount,Amount,Date,Type,DateBegin,DateEnd,CurrencyId")] tbCredits tbCredits)
        {
            if (ModelState.IsValid)
            {
                db.tbCredits.Add(tbCredits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCredits.UserId);
            return View(tbCredits);
        }

        // GET: Credits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCredits tbCredits = db.tbCredits.Find(id);
            if (tbCredits == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCredits.UserId);
            return View(tbCredits);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditId,UserId,MethodId,FullAmount,Amount,Date,Type,DateBegin,DateEnd,CurrencyId")] tbCredits tbCredits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCredits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCredits.UserId);
            return View(tbCredits);
        }

        // GET: Credits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCredits tbCredits = db.tbCredits.Find(id);
            if (tbCredits == null)
            {
                return HttpNotFound();
            }
            return View(tbCredits);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCredits tbCredits = db.tbCredits.Find(id);
            db.tbCredits.Remove(tbCredits);
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
