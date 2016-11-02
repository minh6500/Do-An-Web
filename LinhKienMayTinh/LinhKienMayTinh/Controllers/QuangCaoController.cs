using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class QuangCaoController : Controller
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        // GET: QuangCao
        public ActionResult QuangCao()
        {
            var quangcao = db.QUANGCAOs.ToList();
            return View(quangcao);
        }
    }
}