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
    public class SearchController : Controller
    {
        // GET: Admin/Search
        
        QLBANHANGEntities db = new QLBANHANGEntities();

        #region Search Sản Phẩm
        [HttpPost]
        public ActionResult SearchSanPham(FormCollection f, int? page)
        {
            string sTuKhoa = f["txt_TimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa)).ToList();

            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy" + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult SearchSanPham(string sTuKhoa, int? page)
        {

            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy " + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Search Khách Hàng
        [HttpPost]
        public ActionResult SearchKhachHang(FormCollection f, int? page)
        {
            string sTuKhoa = f["txt_TimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<KHACHHANG> lstKQTK = db.KHACHHANGs.Where(n => n.TENKH.Contains(sTuKhoa)).ToList();

            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy" + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENKH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult SearchKhachHang(string sTuKhoa, int? page)
        {

            List<KHACHHANG> lstKQTK = db.KHACHHANGs.Where(n => n.TENKH.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy " + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENKH).ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Search Đơn Đặt Hàng
        [HttpPost]
        public ActionResult SearchDonDatHang(FormCollection f, int? page)
        {
            string sTuKhoa = f["txt_TimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<DONDATHANG> lstKQTK = db.DONDATHANGs.Where(n => n.KHACHHANG.TENKH.Contains(sTuKhoa)).ToList();

            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy" + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.KHACHHANG.TENKH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult SearchDonDatHang(string sTuKhoa, int? page)
        {

            List<DONDATHANG> lstKQTK = db.DONDATHANGs.Where(n => n.KHACHHANG.TENKH.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy " + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.KHACHHANG.TENKH).ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Search Admin
        [HttpPost]
        public ActionResult SearchAdmin(FormCollection f, int? page)
        {
            string sTuKhoa = f["txt_TimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<ADMINLOGIN> lstKQTK = db.ADMINLOGINs.Where(n => n.TENAD.Contains(sTuKhoa)).ToList();

            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy" + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENAD).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult SearchAdmin(string sTuKhoa, int? page)
        {

            List<ADMINLOGIN> lstKQTK = db.ADMINLOGINs.Where(n => n.TENAD.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin";
                return View();
            }
            ViewBag.ThongBao = "Đã tìm thấy " + " " + lstKQTK.Count + " " + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENAD).ToPagedList(pageNumber, pageSize));
        }
        #endregion


    }
}