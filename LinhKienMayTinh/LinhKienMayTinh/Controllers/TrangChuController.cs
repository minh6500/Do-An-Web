using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

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

        public ActionResult SPTheoLoai(int id)
        {
            var sp = from s in db.SANPHAMs where s.MALOAI == id select s;
            return View(sp);
        }
        public ActionResult SPTheoNSX(int id)
        {
            var a = from s in db.SANPHAMs where s.MANSX == id select s;
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
    }
}