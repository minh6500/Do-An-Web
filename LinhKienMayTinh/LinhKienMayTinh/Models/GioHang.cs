using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhKienMayTinh.Models
{
    
    public class GioHang
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        public int iMASP { get; set; }
        public string sTENSP { get; set; }
        public string sHINHANH { get; set; }
        public double dDONGIA { get; set; }
        public int iSOLUONG { get; set; }
        public double dTHANHTIEN
        {
            get { return iSOLUONG * dDONGIA; }
        }

        //Hàm tạo giỏ hàng
        public GioHang(int MASP)
        {
            iMASP = MASP;
            SANPHAM sanpham = db.SANPHAMs.Single(n => n.MASP == iMASP);
            sTENSP = sanpham.TENSP;
            sHINHANH = sanpham.HINHANH;
            dDONGIA = double.Parse(sanpham.DONGIA.ToString());
            iSOLUONG = 1;           
        }
    }
}