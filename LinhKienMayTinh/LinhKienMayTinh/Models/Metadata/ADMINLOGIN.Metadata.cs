using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(ADMINLOGINMetadata))]
    public partial class ADMINLOGIN
    {
        internal sealed class ADMINLOGINMetadata
        {

            [Display(Name = "Họ Tên")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TENAD { get; set; }

            [Display(Name = "Tài Khoản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string USERNAME { get; set; }

            [Display(Name = "Mật Khẩu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string PASS { get; set; }
        }
    }
}