using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f, int? id)
        {
            string taikhoan = f["USERNAME"].ToString();
            string matkhau = f["PASS"].ToString();
            ADMINLOGIN ad = db.ADMINLOGINs.SingleOrDefault(a => a.USERNAME == taikhoan && a.PASS == matkhau);
            if (ad != null)
            {
                Session["admin"] = ad;
                return RedirectToAction("Index","Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng. Vui lòng kiểm tra lại !";
            return View();
        }

    }
}