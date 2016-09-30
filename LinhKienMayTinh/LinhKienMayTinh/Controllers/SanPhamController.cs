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
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult SanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = db.SANPHAMs.OrderByDescending(a => a.NGAYCAPNHAT).ToList().ToPagedList(pageNumber, pageSize);
            return View(sp);
        }
    }
}