using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QLBANHANGEntities db = new QLBANHANGEntities();
        private List<SANPHAM> SanPhamMoi(int count)
        {
            //sap xep theo ngaycapnhat
            return db.SANPHAMs.OrderByDescending(a => a.NGAYCAPNHAT).Take(count).ToList();
        }
        public ActionResult SanPham()
        {
            var sp = SanPhamMoi(8);
            return View(sp);
        }
    }
}