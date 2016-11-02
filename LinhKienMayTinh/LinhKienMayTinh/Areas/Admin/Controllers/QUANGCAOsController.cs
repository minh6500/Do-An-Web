using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using System.IO;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class QUANGCAOsController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/QUANGCAOs
        public ActionResult Index()
        {
            return View(db.QUANGCAOs.ToList());
        }

        // GET: Admin/QUANGCAOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }

        // GET: Admin/QUANGCAOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QUANGCAOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAQC,HINHANH,LINK,CLASS,ALT")] QUANGCAO qUANGCAO)
        {
            if (ModelState.IsValid)
            {
                db.QUANGCAOs.Add(qUANGCAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANGCAO);
        }

        // GET: Admin/QUANGCAOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(QUANGCAO qUANGCAO, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng nhập dữ liệu hình ảnh";
                return View();
            }
            //Lưu Tên File
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/images"), fileName);
            fileUpload.SaveAs(path);
            qUANGCAO.HINHANH = fileUpload.FileName;
            if (ModelState.IsValid)
            {
                db.Entry(qUANGCAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANGCAO);
        }

        // GET: Admin/QUANGCAOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }

        // POST: Admin/QUANGCAOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            db.QUANGCAOs.Remove(qUANGCAO);
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
