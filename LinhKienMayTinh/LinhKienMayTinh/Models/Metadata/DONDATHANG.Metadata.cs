using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(DONDATHANGMetadata))]
    public partial class DONDATHANG
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class DONDATHANGMetadata
        {

            [Display(Name = "Ngày Đặt")]
            public System.DateTime NGAYDAT { get; set; }

            [Display(Name = "Địa Chỉ Giao")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]
            public string DIACHIGIAO { get; set; }

            [Display(Name = "Người Nhận")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]
            public string TENDAIDIEN { get; set; }

            [Display(Name = "Số Điện Thoại")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]
            public string SDT { get; set; }

            [Display(Name = "Tình Trạng Thanh Toán")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]
            public Nullable<bool> TINHTRANGTHANHTOAN { get; set; }

            [Display(Name = "Tình Trạng Giao Hàng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]
            public Nullable<bool> TINHTRANGGIAOHANG { get; set; }
        }
    }
}