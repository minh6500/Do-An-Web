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
    public class LOAISPsController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/LOAISPs
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.LOAISPs.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/LOAISPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // GET: Admin/LOAISPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LOAISPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAI,TENLOAI")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.LOAISPs.Add(lOAISP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAISP);
        }

        // GET: Admin/LOAISPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: Admin/LOAISPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAI,TENLOAI")] LOAISP lOAISP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAISP);
        }

        // GET: Admin/LOAISPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISP lOAISP = db.LOAISPs.Find(id);
            if (lOAISP == null)
            {
                return HttpNotFound();
            }
            return View(lOAISP);
        }

        // POST: Admin/LOAISPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAISP lOAISP = db.LOAISPs.Find(id);
            db.LOAISPs.Remove(lOAISP);
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
