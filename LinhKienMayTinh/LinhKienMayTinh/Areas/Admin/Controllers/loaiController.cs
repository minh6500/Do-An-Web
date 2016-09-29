using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class loaiController : Controller
    {
        // GET: Admin/loaisp
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult loai()
        {
            var sp = db.LOAISPs.ToList();
            return View(sp);
        }
    }
}