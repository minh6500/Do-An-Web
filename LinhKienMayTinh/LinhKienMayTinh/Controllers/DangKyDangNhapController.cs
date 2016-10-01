using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class DangKyDangNhapController : Controller
    {
        // GET: DangKyDangNhap
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG kh)
        {
            kh.NGAYDANGKY = DateTime.Now;
            if (ModelState.IsValid)
            {               
                //Insert dữ liệu vào bảng khách hàng
                db.KHACHHANGs.Add(kh);
                //lưu vào csdl
                db.SaveChanges();
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string taikhoan = f["ID"].ToString();
            string matkhau = f["PASS"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.ID == taikhoan && n.PASS == matkhau);
            if(kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng. Vui lòng kiểm tra lại !";
            return View();
        }
    }
}