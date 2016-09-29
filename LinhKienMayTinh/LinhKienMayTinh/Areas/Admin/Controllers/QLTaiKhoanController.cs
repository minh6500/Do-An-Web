using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using PagedList;
using PagedList.Mvc;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        // GET: Admin/QLTaiKhoan
        public ActionResult QLTaiKhoan(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var tk = db.KHACHHANGs.ToList().OrderByDescending(n => n.NGAYDANGKY).ToPagedList(pageNumber, pageSize);
            return View(tk);
        }

        //Thêm tài khoản
        [HttpGet]
        public ActionResult ThemTK()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemTK(KHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(khachhang);
                db.SaveChanges();
            }
            return RedirectToAction("QLTaiKhoan");
        }

        //Sửa tài khoản
        [HttpGet]
        public ActionResult SuaTK(int iMAKH)
        {
            //Lấy tài khoản theo mã
            KHACHHANG khachhang = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == iMAKH);
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaTK(KHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("QLTaiKhoan");
        }

        //Xóa tài khoản
        [HttpGet]
        public ActionResult XoaTK(int iMAKH)
        {
            KHACHHANG khachhang = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == iMAKH);
            if(khachhang==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }
        [HttpPost,ActionName("XoaTK")]
       
        public ActionResult XacNhanXoa(int iMAKH)
        {
            KHACHHANG khachhang = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == iMAKH);
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("QLTaiKhoan");
        }
    }
}