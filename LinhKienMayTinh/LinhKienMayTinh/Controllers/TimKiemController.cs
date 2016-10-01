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
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QLBANHANGEntities db = new QLBANHANGEntities();

        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
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
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả";
            return View(lstKQTK.OrderBy(n=>n.TENSP).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa)).ToList();

            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
                return View(db.SANPHAMs.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + "kết quả";
            return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
        }
    }
}