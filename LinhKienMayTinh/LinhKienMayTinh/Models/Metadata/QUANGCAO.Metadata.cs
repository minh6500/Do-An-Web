using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(QUANGCAOMetadata))]
    public partial class QUANGCAO
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class QUANGCAOMetadata
        {
            [Display(Name = "Đường Dẫn")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string LINK { get; set; }

            [Display(Name = "Hình Ảnh")]
            public string HINHANH { get; set; }
        }
    }
}