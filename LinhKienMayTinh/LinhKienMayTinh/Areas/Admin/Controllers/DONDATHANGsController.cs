﻿using System;
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
using System.IO;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class DONDATHANGsController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/DONDATHANGs
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.DONDATHANGs.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DonDatHangDaThanhToan(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var dONDATHANGs = db.DONDATHANGs.Where(n => n.TINHTRANGTHANHTOAN == true);
            return View(dONDATHANGs.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DonDatHangChuaThanhToan(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var dONDATHANGs = db.DONDATHANGs.Where(n => n.TINHTRANGTHANHTOAN == false);
            return View(dONDATHANGs.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DonDatHangDaGiaoHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var dONDATHANGs = db.DONDATHANGs.Where(n => n.TINHTRANGGIAOHANG == true);
            return View(dONDATHANGs.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DonDatHangChuaGiaoHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var dONDATHANGs = db.DONDATHANGs.Where(n => n.TINHTRANGGIAOHANG == false);
            return View(dONDATHANGs.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult CHITIET (int? id)
        {
            List<CTDDH> cTDDHs = db.CTDDHs.Where(n => n.MAD == id).ToList();
            return View(cTDDHs);
        }
        // GET: Admin/DONDATHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // GET: Admin/DONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH");
            return View();
        }

        // POST: Admin/DONDATHANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAD,NGAYDAT,TENDAIDIEN,SDT,DIACHIGIAO,TINHTRANGTHANHTOAN,TINHTRANGGIAOHANG,MAKH")] DONDATHANG dONDATHANG)
        {
            dONDATHANG.NGAYDAT = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.DONDATHANGs.Add(dONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONDATHANG.MAKH);
            return View(dONDATHANG);
        }

        // GET: Admin/DONDATHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONDATHANG.MAKH);
            return View(dONDATHANG);
        }

        // POST: Admin/DONDATHANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAD,NGAYDAT,TENDAIDIEN,SDT,DIACHIGIAO,TINHTRANGTHANHTOAN,TINHTRANGGIAOHANG,MAKH")] DONDATHANG dONDATHANG)
        {
            var ngaydat = dONDATHANG.NGAYDAT;
            if (ModelState.IsValid)
            {
                dONDATHANG.NGAYDAT = ngaydat;
                db.Entry(dONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONDATHANG.MAKH);
            return View(dONDATHANG);
        }

        // GET: Admin/DONDATHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // POST: Admin/DONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            db.DONDATHANGs.Remove(dONDATHANG);
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
