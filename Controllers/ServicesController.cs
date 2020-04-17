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
    public class ServicesController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Services
        public ActionResult Index()
        {
            var tbServices = db.tbServices.Include(t => t.tbUsers);
            return View(tbServices.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbServices tbServices = db.tbServices.Find(id);
            if (tbServices == null)
            {
                return HttpNotFound();
            }
            return View(tbServices);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,UserId,MethodId,Amount,Date,IsClosed,CurrencyId")] tbServices tbServices)
        {
            if (ModelState.IsValid)
            {
                db.tbServices.Add(tbServices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbServices.UserId);
            return View(tbServices);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbServices tbServices = db.tbServices.Find(id);
            if (tbServices == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbServices.UserId);
            return View(tbServices);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceId,UserId,MethodId,Amount,Date,IsClosed,CurrencyId")] tbServices tbServices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbServices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbServices.UserId);
            return View(tbServices);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbServices tbServices = db.tbServices.Find(id);
            if (tbServices == null)
            {
                return HttpNotFound();
            }
            return View(tbServices);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbServices tbServices = db.tbServices.Find(id);
            db.tbServices.Remove(tbServices);
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
