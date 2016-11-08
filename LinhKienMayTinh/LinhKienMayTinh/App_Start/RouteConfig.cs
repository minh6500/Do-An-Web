using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinhKienMayTinh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "LienHe", action = "LienHe", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "DangKyDangNhap", action = "DangNhap", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky",
                defaults: new { controller = "DangKyDangNhap", action = "DangKy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DoiMatKhau",
                url: "doi-mat-khau/{id}",
                defaults: new { controller = "DangKyDangNhap", action = "DoiMatKhau", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                
                name: "ThongTinTaiKhoan",
                url: "thong-tin-tai-khoan/{id}",
                defaults: new { controller = "DangKyDangNhap", action = "ThongTinTaiKhoan", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "DatHang",
                url: "dat-hang",
                defaults: new { controller = "GioHang", action = "DatHang", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "ThanhToanThanhCong",
                url: "thanh-toan-thanh-cong",
                defaults: new { controller = "GioHang", action = "ThanhToanThanhCong", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "KetQuaTimKiem",
                url: "ket-qua-tim-kiem",
                defaults: new { controller = "TimKiem", action = "KetQuaTimKiem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SanPham",
                url: "san-pham",
                defaults: new { controller = "SanPham", action = "SanPham", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "ChiTietSanPham",
                 url: "chi-tiet-san-pham/{URL}-{id}",
                 defaults: new { controller = "TrangChu", action = "XemChiTiet", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                 name: "SanPhamTheoLoai",
                 url: "san-pham/{URL}-{id}",
                 defaults: new { controller = "TrangChu", action = "SPTheoLoai", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                 name: "NSX",
                 url: "san-pham/{URL}-{id}",
                 defaults: new { controller = "TrangChu", action = "SPTheoNSX", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
