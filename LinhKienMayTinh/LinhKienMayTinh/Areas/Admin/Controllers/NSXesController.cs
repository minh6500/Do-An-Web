using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using PagedList;
using PagedList.Mvc;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class NSXesController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/NSXes
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.NSXes.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/NSXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // GET: Admin/NSXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NSXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANSX,TENNSX,URL")] NSX nSX)
        {
            if (ModelState.IsValid)
            {
                db.NSXes.Add(nSX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nSX);
        }

        // GET: Admin/NSXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // POST: Admin/NSXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANSX,TENNSX,URL")] NSX nSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nSX);
        }

        // GET: Admin/NSXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // POST: Admin/NSXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NSX nSX = db.NSXes.Find(id);
            db.NSXes.Remove(nSX);
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
