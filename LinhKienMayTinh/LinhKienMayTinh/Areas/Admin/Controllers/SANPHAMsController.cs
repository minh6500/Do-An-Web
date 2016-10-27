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
    public class SANPHAMsController : Controller
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: Admin/SANPHAMs
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var sanpham = db.SANPHAMs.ToList();
            return View(sanpham.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SanPhamTheoLoai(int? page, int id)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var sanpham = from s in db.SANPHAMs where s.MALOAI == id select s;
            return View("SanPhamTheoLoai", sanpham.ToList().OrderByDescending(n => n.NGAYCAPNHAT).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI");
            ViewBag.MANSX = new SelectList(db.NSXes, "MANSX", "TENNSX");
            return View();
        }

        // POST: Admin/SANPHAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SANPHAM sANPHAM, HttpPostedFileBase fileUpload)
        {

            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            ViewBag.MANSX = new SelectList(db.NSXes, "MANSX", "TENNSX", sANPHAM.MANSX);
            //Lưu Tên File
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/images"), fileName);
            if (ModelState.IsValid)
            {
                fileUpload.SaveAs(path);
                sANPHAM.HINHANH = fileUpload.FileName;
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            ViewBag.MANSX = new SelectList(db.NSXes, "MANSX", "TENNSX", sANPHAM.MANSX);
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MOTA,HINHANH,DONGIA,NGAYCAPNHAT,THANHTOANTRUCTUYEN,MALOAI,MANSX")]SANPHAM sANPHAM, HttpPostedFileBase fileUpload)
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs, "MALOAI", "TENLOAI", sANPHAM.MALOAI);
            ViewBag.MANSX = new SelectList(db.NSXes, "MANSX", "TENNSX", sANPHAM.MANSX);
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/images"), fileName);

            if (ModelState.IsValid)
            {
                //Kiểm tra hình ảnh
                fileUpload.SaveAs(path);
                sANPHAM.HINHANH = fileUpload.FileName;
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
