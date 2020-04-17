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
    public class CapitalsController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Capitals
        public ActionResult Index()
        {
            var tbCapitals = db.tbCapitals.Include(t => t.tbUsers);
            return View(tbCapitals.ToList());
        }

        // GET: Capitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCapitals tbCapitals = db.tbCapitals.Find(id);
            if (tbCapitals == null)
            {
                return HttpNotFound();
            }
            return View(tbCapitals);
        }

        // GET: Capitals/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Capitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CapitalId,UserId,MethodId,FullAmount,Amount,CurrencyId,Date,Type,DateBegin,DateEnd")] tbCapitals tbCapitals)
        {
            if (ModelState.IsValid)
            {
                db.tbCapitals.Add(tbCapitals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCapitals.UserId);
            return View(tbCapitals);
        }

        // GET: Capitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCapitals tbCapitals = db.tbCapitals.Find(id);
            if (tbCapitals == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCapitals.UserId);
            return View(tbCapitals);
        }

        // POST: Capitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CapitalId,UserId,MethodId,FullAmount,Amount,CurrencyId,Date,Type,DateBegin,DateEnd")] tbCapitals tbCapitals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCapitals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbCapitals.UserId);
            return View(tbCapitals);
        }

        // GET: Capitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCapitals tbCapitals = db.tbCapitals.Find(id);
            if (tbCapitals == null)
            {
                return HttpNotFound();
            }
            return View(tbCapitals);
        }

        // POST: Capitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCapitals tbCapitals = db.tbCapitals.Find(id);
            db.tbCapitals.Remove(tbCapitals);
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
