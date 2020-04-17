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
    public class CurrenciesController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Currencies
        public ActionResult Index()
        {
            return View(db.tbCurrency.ToList());
        }

        // GET: Currencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurrency tbCurrency = db.tbCurrency.Find(id);
            if (tbCurrency == null)
            {
                return HttpNotFound();
            }
            return View(tbCurrency);
        }

        // GET: Currencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrencyId,Name")] tbCurrency tbCurrency)
        {
            if (ModelState.IsValid)
            {
                db.tbCurrency.Add(tbCurrency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbCurrency);
        }

        // GET: Currencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurrency tbCurrency = db.tbCurrency.Find(id);
            if (tbCurrency == null)
            {
                return HttpNotFound();
            }
            return View(tbCurrency);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrencyId,Name")] tbCurrency tbCurrency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCurrency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbCurrency);
        }

        // GET: Currencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurrency tbCurrency = db.tbCurrency.Find(id);
            if (tbCurrency == null)
            {
                return HttpNotFound();
            }
            return View(tbCurrency);
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCurrency tbCurrency = db.tbCurrency.Find(id);
            db.tbCurrency.Remove(tbCurrency);
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
