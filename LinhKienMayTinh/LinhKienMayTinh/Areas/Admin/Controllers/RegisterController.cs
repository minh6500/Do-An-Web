using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;


namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ADMINLOGIN ad, FormCollection f)
        {
            var xacnhan = f["XACNHAN"];
            var ten = f["TENAD"];
            var taikhoan = f["USERNAME"];
            var pass = f["PASS"];
            var admin = db.ADMINLOGINs.ToList();
            foreach (var item in admin)
            {
                if (taikhoan == item.USERNAME)
                {
                    ViewBag.ThongBaoUserName = "Tên tài khoản đã có người sử dụng";
                    return View();
                }
            }
            if (ten == "Họ Tên" || taikhoan == "Tài Khoản" || pass == "Mật Khẩu" || xacnhan == "Mật Khẩu")
            {
                ViewBag.ThongBao = "Vui Lòng Nhập Đầy Đủ Dữ Liệu";
                return View();
            }
            if (ModelState.IsValid)
            {
                if (ad.PASS != xacnhan)
                {
                    ViewBag.ThongBaoXacNhan = "Xác Nhận Mật Khẩu Không Chính Xác !";
                    return View();
                }
                db.ADMINLOGINs.Add(ad);
                //lưu vào csdl
                db.SaveChanges();
                return RedirectToAction("Index", "ADMINLOGINs");
            }
            return View();
        }

    }
}