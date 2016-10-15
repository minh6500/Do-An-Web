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
    public class KhuyenMaiController : Controller
    {
        // GET: Admin/KhuyenMai
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult KhuyenMai10(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = db.SANPHAMs.Where(n => n.KHUYENMAI.TENKM == "GIAM 10%").ToList();
            if(sp.Count == 0)
            {
                ViewBag.ThongBao = "Không Có Sản Phẩm Nào!!!";
            }
            return View(sp.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult KhuyenMai20(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = db.SANPHAMs.Where(n => n.KHUYENMAI.TENKM == "GIAM 20%").ToList();
            return View(sp.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult KhuyenMai30(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = db.SANPHAMs.Where(n => n.KHUYENMAI.TENKM == "GIAM 30%").ToList();
            return View(sp.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SanPhamKhuyenMai(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = db.SANPHAMs.Where(n => n.KHUYENMAI.TENKM == "GIAM 10%" || n.KHUYENMAI.TENKM == "GIAM 20%" || n.KHUYENMAI.TENKM == "GIAM 30%").ToList();
            return View(sp.ToPagedList(pageNumber, pageSize));
        }
    }
}