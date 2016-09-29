using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace LinhKienMayTinh.Areas.Admin.Controllers
{
    public class tatcaspController : Controller
    {
        // GET: Admin/tatcasp
        QLBANHANGEntities db = new QLBANHANGEntities();
        
        public ActionResult tatcasp(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var sp = db.SANPHAMs.ToList().OrderByDescending(n=>n.NGAYCAPNHAT).ToPagedList(pageNumber,pageSize);
            return View(sp);
        }
        public ActionResult SanPhamTheoLoai(int? page,int id)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var sanpham = from s in db.SANPHAMs where s.MALOAI == id select s;
            return View("SanPhamTheoLoai",sanpham.ToList().OrderByDescending(n => n.NGAYCAPNHAT).ToPagedList(pageNumber, pageSize));
        }
        //Them moi san pham
        [HttpGet]
        public ActionResult ThemSP()
        {
            //Đổi Thành dropdownlist
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList(),"MALOAI","TENLOAI");
            ViewBag.MANSX = new SelectList(db.NSXes.ToList(), "MANSX", "TENNSX");
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs.ToList(), "MAKM", "TENKM");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSP(SANPHAM sanpham,HttpPostedFileBase fileupload)
        {
            //Đổi Thành dropdownlist
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList(), "MALOAI", "TENLOAI");
            ViewBag.MANSX = new SelectList(db.NSXes.ToList(), "MANSX", "TENNSX");
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs.ToList(), "MAKM", "TENKM");
            //Kiểm tra đường dẫn ảnh bìa
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn hình ảnh";
                return View();
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid) //nếu mà thỏa mãn tất cả điều kiện của textbox trong metadata chưa
            {
                //Lưu tên của file
                var filename = Path.GetFileName(fileupload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                sanpham.HINHANH = fileupload.FileName;
                //thêm vào cơ sở dữ liệu
                db.SANPHAMs.Add(sanpham);
                db.SaveChanges();
            }
            return View();
        }
        //Sửa sản phẩm
        [HttpGet]
        public ActionResult SuaSP(int id)
        {
            //Lấy ra sản phẩm theo mã
            SANPHAM sanpham = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đổi thành dropdownlist
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList(),"MALOAI", "TENLOAI",sanpham.MALOAI);
            ViewBag.MANSX = new SelectList(db.NSXes.ToList(), "MANSX", "TENNSX",sanpham.MANSX);
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs.ToList(), "MAKM", "TENKM",sanpham.MAKM);
            return View(sanpham);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSP(SANPHAM sanpham, HttpPostedFileBase fileupload,string MOTA)
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList(), "MALOAI", "TENLOAI", sanpham.MALOAI);
            ViewBag.MANSX = new SelectList(db.NSXes.ToList(), "MANSX", "TENNSX", sanpham.MANSX);
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs.ToList(), "MAKM", "TENKM", sanpham.MAKM);
            sanpham.MOTA = MOTA;
            if (ModelState.IsValid)
            {
                if (fileupload == null)
                {
                    ViewBag.ThongBao = "Vui lòng chọn hình ảnh";
                    return View();
                }
                //Lưu tên của file
                var filename = Path.GetFileName(fileupload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                //Kiểm tra đường dẫn ảnh bìa
                else
                {
                    fileupload.SaveAs(path);
                }
                sanpham.HINHANH = fileupload.FileName;
                //Thực hiện cập nhật trong model
                db.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("tatcasp");
        }
        //Sửa sản phẩm
        [HttpGet]
        public ActionResult HienThiSP(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if(sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        // end sửa san phẩm

        //Xóa sản phẩm
        [HttpGet]
        public ActionResult XoaSP(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.SingleOrDefault(a => a.MASP == id);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("XoaSP")]
        public ActionResult XacNhanXoa(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if(sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAMs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("tatcasp");
        }
    }
}