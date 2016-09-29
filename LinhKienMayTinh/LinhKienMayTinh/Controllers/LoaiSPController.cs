using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: LoaiSP
        QLBANHANGEntities db = new QLBANHANGEntities();
        public ActionResult LoaiSP()
        {
            return PartialView(db.LOAISPs.ToList());
        }
    }
}