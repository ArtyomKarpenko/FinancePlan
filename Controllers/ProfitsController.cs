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
    public class ProfitsController : Controller
    {
        private FinancePlanEntities db = new FinancePlanEntities();

        // GET: tbProfits
        public ActionResult Index()
        {
            var tbProfit = db.tbProfit.Include(t => t.tbUsers);
            return View(tbProfit.ToList());
        }

        // GET: tbProfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfit tbProfit = db.tbProfit.Find(id);
            if (tbProfit == null)
            {
                return HttpNotFound();
            }
            return View(tbProfit);
        }

        // GET: tbProfits/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: tbProfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfitId,UserId,MethodId,Amount,Date,CurrencyId")] tbProfit tbProfit)
        {
            if (ModelState.IsValid)
            {
                db.tbProfit.Add(tbProfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfit.UserId);
            return View(tbProfit);
        }

        // GET: tbProfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfit tbProfit = db.tbProfit.Find(id);
            if (tbProfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfit.UserId);
            return View(tbProfit);
        }

        // POST: tbProfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfitId,UserId,MethodId,Amount,Date,CurrencyId")] tbProfit tbProfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfit.UserId);
            return View(tbProfit);
        }

        // GET: tbProfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfit tbProfit = db.tbProfit.Find(id);
            if (tbProfit == null)
            {
                return HttpNotFound();
            }
            return View(tbProfit);
        }

        // POST: tbProfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProfit tbProfit = db.tbProfit.Find(id);
            db.tbProfit.Remove(tbProfit);
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
