﻿using System;
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
        private FinanceEntities db = new FinanceEntities();

        // GET: Profits
        public ActionResult Index()
        {
            var tbProfits = db.tbProfits.Include(t => t.tbUsers);
            return View(tbProfits.ToList());
        }

        // GET: Profits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfits tbProfits = db.tbProfits.Find(id);
            if (tbProfits == null)
            {
                return HttpNotFound();
            }
            return View(tbProfits);
        }

        // GET: Profits/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Profits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfitId,UserId,MethodId,Amount,Date,CurrencyId")] tbProfits tbProfits)
        {
            if (ModelState.IsValid)
            {
                db.tbProfits.Add(tbProfits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfits.UserId);
            return View(tbProfits);
        }

        // GET: Profits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfits tbProfits = db.tbProfits.Find(id);
            if (tbProfits == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfits.UserId);
            return View(tbProfits);
        }

        // POST: Profits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfitId,UserId,MethodId,Amount,Date,CurrencyId")] tbProfits tbProfits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProfits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbProfits.UserId);
            return View(tbProfits);
        }

        // GET: Profits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfits tbProfits = db.tbProfits.Find(id);
            if (tbProfits == null)
            {
                return HttpNotFound();
            }
            return View(tbProfits);
        }

        // POST: Profits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProfits tbProfits = db.tbProfits.Find(id);
            db.tbProfits.Remove(tbProfits);
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
