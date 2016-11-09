using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using PagedList;
using PagedList.Mvc;

namespace LinhKienMayTinh.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        QLBANHANGEntities db = new QLBANHANGEntities();
        private List<SANPHAM> SanPhamMoi(int count)
        {
            //sap xep theo ngaycapnhat
            return db.SANPHAMs.OrderByDescending(a => a.NGAYCAPNHAT).Take(count).ToList();
        }
        public ActionResult Index()
        {
            ViewBag.TrangChu = "Trang Chủ";
            var sp = SanPhamMoi(8);
            return View(sp);
        }

        public ActionResult SPTheoLoai(int id,int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = (from s in db.SANPHAMs where s.MALOAI == id select s).ToList().ToPagedList(pageNumber, pageSize);
            return View(sp);
        }
        public ActionResult SPTheoNSX(int? id, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var a = (from n in db.SANPHAMs where n.MANSX == id select n).ToList().ToPagedList(pageNumber, pageSize);
            return View(a);
        }
        public ActionResult XemChiTiet(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if (sp == null)
            {
                //tra ve trang bao loi 404
                Response.StatusCode = 404;
            }
            return View(sp);
        }
        public ActionResult SanPhamKhac()
        {
            var rd = db.SANPHAMs.LaySanPhamNgauNhien(4).ToList();
            return View(rd);
        }
    }
}