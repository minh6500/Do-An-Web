using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class ADMINLOGINsController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/ADMINLOGINs
        public ActionResult Index()
        {
            return View(db.ADMINLOGINs.ToList());
        }

        // GET: Admin/ADMINLOGINs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINLOGIN aDMINLOGIN = db.ADMINLOGINs.Find(id);
            if (aDMINLOGIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMINLOGIN);
        }

        // GET: Admin/ADMINLOGINs/Create
        public ActionResult Create()
        {
            return RedirectToAction("Register", "Register");
        }



        // GET: Admin/ADMINLOGINs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINLOGIN aDMINLOGIN = db.ADMINLOGINs.Find(id);
            if (aDMINLOGIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMINLOGIN);
        }

        // POST: Admin/ADMINLOGINs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAAD,USERNAME,PASS")] ADMINLOGIN aDMINLOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMINLOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMINLOGIN);
        }

        // GET: Admin/ADMINLOGINs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINLOGIN aDMINLOGIN = db.ADMINLOGINs.Find(id);
            if (aDMINLOGIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMINLOGIN);
        }

        // POST: Admin/ADMINLOGINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMINLOGIN aDMINLOGIN = db.ADMINLOGINs.Find(id);
            db.ADMINLOGINs.Remove(aDMINLOGIN);
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
