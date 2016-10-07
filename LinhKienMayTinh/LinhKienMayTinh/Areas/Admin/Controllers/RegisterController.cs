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
        public ActionResult Register(ADMINLOGIN ad)
        {
            if (ModelState.IsValid)
            {
                //Insert dữ liệu vào bảng khách hàng
                db.ADMINLOGINs.Add(ad);
                //lưu vào csdl
                db.SaveChanges();
                return RedirectToAction("Index", "ADMINLOGINs");
            }
            return View();
        }

    }
}