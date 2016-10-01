using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinhKienMayTinh.Models;

namespace LinhKienMayTinh.Controllers
{
    public class GioHangController : Controller
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        #region Giỏ Hàng
        //Lấy session giỏ hàng
        public List<GioHang> LayGioHang()
        {                                                 //ép kiểu          
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tạo list giỏ hàng
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int id,string strURL)
        {
            //Lấy session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session[GioHang] hay không
            GioHang ghsanpham = lstGioHang.Find(n => n.iMASP == id); //Kiểm tra sản phẩm này đã tồn tại trong session[GioHang] hay chưa
            //Nếu không tồn tại thì add vào
            if (ghsanpham == null)
            {
                ghsanpham = new GioHang(id);
                //add sản phẩm mới vào giỏ hàng
                lstGioHang.Add(ghsanpham);
                return Redirect(strURL);
            }
            //Nếu tồn tại thì số lượng ++
            else
            {
                ghsanpham.iSOLUONG++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMASP,FormCollection f)
        {
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session[GioHang] hay không
            GioHang ghsanpham = lstGioHang.SingleOrDefault(n => n.iMASP == iMASP);
            //Nếu tồn tại thì cho sửa số lượng
            if (ghsanpham != null)
            {
                ghsanpham.iSOLUONG = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMASP)
        {
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session[GioHang] hay không
            GioHang ghsanpham = lstGioHang.SingleOrDefault(n => n.iMASP == iMASP);
            if(ghsanpham !=null)
            {
                lstGioHang.RemoveAll(n => n.iMASP == iMASP);
            }
            if (lstGioHang.Count == 0)
            {
                ViewBag.ThongBao = "Giỏ hàng rỗng! Hãy chọn sản phẩm cần mua.";
            }
            return RedirectToAction("GioHang");
        }

        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                ViewBag.ThongBao = "Giỏ hàng rỗng! Hãy chọn sản phẩm cần mua.";
            }
            ViewBag.Tongtien = TongTien();
            return View(lstGioHang);
        }

        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSOLUONG);
            }
            
            return iTongSoLuong;
        }

        //Tính tổng tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dTHANHTIEN);
            }
            
            return dTongTien;
        }

        //Tạo Giỏ Hàng Partial chứa tổng số lượng và tổng tiền
        public ActionResult GioHangPartial()
        {
            if(TongSoLuong() == 0 )
            {
                return PartialView();
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        #endregion

        #region Đặt Hàng
        //Xây dựng trang đặt hàng
        [HttpGet]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng nhập
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return View();
        }
        
        [HttpPost, ActionName("DatHang")]
        [ValidateAntiForgeryToken]
        public ActionResult DonDatHang(DONDATHANG ddh)
        {
            
            //Thêm đơn hàng
            List<GioHang> gh = LayGioHang();
            KHACHHANG kh = (KHACHHANG) Session["TaiKhoan"];
            ddh.MAKH = kh.MAKH;
            ddh.NGAYDAT = DateTime.Now;           
            ddh.TINHTRANGGIAOHANG = false;
            ddh.TINHTRANGTHANHTOAN = false;
            if (ModelState.IsValid)
            {
                db.DONDATHANGs.Add(ddh);
                db.SaveChanges();
            }
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CTDDH ctdh = new CTDDH();
                ctdh.MAD = ddh.MAD;
                ctdh.MASP = item.iMASP;
                ctdh.SOLUONG = item.iSOLUONG;
                ctdh.DONGIA = (int)item.dDONGIA;
                db.CTDDHs.Add(ctdh);
            }
            db.SaveChanges();
            return RedirectToAction("Index","TrangChu");
        }
        #endregion
    }
}