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
    public class MethodsController : Controller
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: Methods
        public ActionResult Index()
        {
            var tbMethod = db.tbMethod.Include(t => t.tbUsers);
            return View(tbMethod.ToList());
        }

        // GET: Methods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMethod tbMethod = db.tbMethod.Find(id);
            if (tbMethod == null)
            {
                return HttpNotFound();
            }
            return View(tbMethod);
        }

        // GET: Methods/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName");
            return View();
        }

        // POST: Methods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MethodId,UserId,Name,Type,IsClosed")] tbMethod tbMethod)
        {
            if (ModelState.IsValid)
            {
                db.tbMethod.Add(tbMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbMethod.UserId);
            return View(tbMethod);
        }

        // GET: Methods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMethod tbMethod = db.tbMethod.Find(id);
            if (tbMethod == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbMethod.UserId);
            return View(tbMethod);
        }

        // POST: Methods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MethodId,UserId,Name,Type,IsClosed")] tbMethod tbMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbUsers, "UserId", "FirstName", tbMethod.UserId);
            return View(tbMethod);
        }

        // GET: Methods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMethod tbMethod = db.tbMethod.Find(id);
            if (tbMethod == null)
            {
                return HttpNotFound();
            }
            return View(tbMethod);
        }

        // POST: Methods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMethod tbMethod = db.tbMethod.Find(id);
            db.tbMethod.Remove(tbMethod);
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
