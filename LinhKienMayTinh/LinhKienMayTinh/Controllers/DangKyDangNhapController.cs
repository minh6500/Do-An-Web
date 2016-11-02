using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using System.Data.Entity;

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
        public ActionResult DangKy(KHACHHANG kh,FormCollection f)
        {
            kh.NGAYDANGKY = DateTime.Now;
            var xacnhan = f["XACNHAN"];
            var username = db.KHACHHANGs.ToList();
            foreach(var item in username)
            {
                if(f["USERNAME"] == item.USERNAME)
                {
                    ViewBag.ThongBaoUserName = "Tên tài khoản đã có người sử dụng";
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                if (kh.PASS != xacnhan)
                {
                    ViewBag.ThongBaoXacNhan = "Xác Nhận Mật Khẩu Không Chính Xác !";
                    return View();
                }
                else
                {
                    //Insert dữ liệu vào bảng khách hàng
                    db.KHACHHANGs.Add(kh);
                    //lưu vào csdl
                    db.SaveChanges();
                    ViewBag.DangKy = "Chúc mừng bạn đã đăng ký thành công";
                    return View();
                } 
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f, int? id)
        {
            string taikhoan = f["USERNAME"].ToString();
            string matkhau = f["PASS"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.USERNAME == taikhoan && n.PASS == matkhau);
            ADMINLOGIN ad = db.ADMINLOGINs.SingleOrDefault(a => a.USERNAME == taikhoan && a.PASS == matkhau);
            if (ad != null)
            {
                Session["admin"] = ad;
                return RedirectToAction("Index", "Admin");
            }
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng. Vui lòng kiểm tra lại !";
            return View();
        }

        public ActionResult Thoat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "TrangChu");
        }

        public ActionResult ThongTinTaiKhoan(int? id)
        {
            var session = (KHACHHANG)Session["TaiKhoan"];
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(kh);
            }
        }
        [HttpGet]
        public ActionResult DoiMatKhau(int? id)
        {
            var session = (KHACHHANG)Session["TaiKhoan"];
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(KHACHHANG kh, FormCollection f)
        {
            string matkhau = f["PASSWORD"];
            string xacnhan = f["PW"];
            string matkhaumoi = f["PASS"];
            var session = (KHACHHANG)Session["TaiKhoan"];
            if (matkhau == "" || xacnhan == "" || matkhaumoi == "")
            {
                ViewBag.ThongBao = "Vui Lòng Nhập Đầy Đủ Thông Tin Không Được Bỏ Trống";
                return View();
            }
            else
            {
                if (matkhau != session.PASS)
                {
                    ViewBag.ThongBao = "Mật Khẩu Không Đúng Xin Vui Lòng Nhập Lại !";
                    return View();
                }
                else
                {
                    if (xacnhan != matkhaumoi)
                    {
                        ViewBag.ThongBao = "Xác Nhận Mật Khẩu Không Chính Xác !";
                        return View();
                    }
                    else
                    {
                        kh.MAKH = session.MAKH;
                        kh.TENKH = session.TENKH;
                        kh.DIACHI = session.DIACHI;
                        kh.EMAIL = session.EMAIL;
                        kh.NGAYDANGKY = session.NGAYDANGKY;
                        kh.USERNAME = session.USERNAME;
                        kh.SDT = session.SDT;
                        kh.PASS = matkhaumoi;
                        db.Entry(kh).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.ChucMung = "Chúc Mừng Đã Thay Đổi Mật Khẩu Thành Công";
                        return View();
                    }
                }
            }
        }
    }
}