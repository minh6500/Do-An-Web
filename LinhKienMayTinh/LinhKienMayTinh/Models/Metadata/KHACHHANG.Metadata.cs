using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(KHACHHANGMetadata))]
    public partial class KHACHHANG
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class KHACHHANGMetadata
        {
            [Display(Name = "Họ Tên")]                                             //Dặt lại tên cho cột
            [MinLength(5,ErrorMessage ="Tên ít nhất phải 5 ký tự trở lên")]        //kiểm tra độ dài 
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]  //kiểm tra rỗng
            public string TENKH { get; set; }

            [Display(Name ="Địa Chỉ")]
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]
            public string DIACHI { get; set; }

            [Display(Name ="Điện Thoại")]
            [StringLength (11,MinimumLength =10,ErrorMessage ="Vui lòng nhập đúng số điện thoại")]           //giới hạn sđt từ 10-11 số
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]
            public string SDT { get; set; }

            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress, ErrorMessage ="Email không đúng")]                //kiểm tra định dạng email
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]
            public string EMAIL { get; set; }

            [Display(Name = "Tài Khoản")]
            [MinLength(5, ErrorMessage = "Tài khoản ít nhất phải có 5 ký tự trở lên")]
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]
            public string ID { get; set; }

            [Display(Name = "Mật Khẩu")]
            [StringLength(20, MinimumLength = 10, ErrorMessage = "Mật khẩu phải có từ 10-20 ký tự")]
            [Required(ErrorMessage = "{0} Vui lòng nhập dữ liệu cho trường này")]
            public string PASS { get; set; }
        }
    }
}