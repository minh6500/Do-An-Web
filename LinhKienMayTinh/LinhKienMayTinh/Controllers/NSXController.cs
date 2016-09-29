using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class NSXController : Controller
    {
        // GET: NSX
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult NhaSanXuat()
        {
            return PartialView(db.NSXes.ToList());
        }
    }
}