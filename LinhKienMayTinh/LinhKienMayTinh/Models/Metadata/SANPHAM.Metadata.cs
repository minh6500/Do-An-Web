using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(SANPHAMMetadata))]
    public partial class SANPHAM
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class SANPHAMMetadata
        {
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] //định dạng ngày sinh
            [Display(Name = "Ngày Cập Nhật")]                                                //thuộc tính display dùng để đặt lại tên cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này ")]               //kiểm tra rỗng
            public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }

            [Display(Name = "Tên Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TENSP { get; set; }

            [Display(Name = "Đơn Giá")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public double DONGIA { get; set; }

            [Display (Name ="Mã Sản Phẩm")]
            public int MASP { get; set; }

            [Display(Name = "Mô Tả")]
            public string MOTA { get; set; }

            [Display(Name = "Hình Ảnh")]            
            public string HINHANH { get; set; }



        }
    }
}