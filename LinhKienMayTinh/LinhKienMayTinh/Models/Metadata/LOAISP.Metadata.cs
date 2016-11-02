using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(LOAISPMetadata))]
    public partial class LOAISP
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class LOAISPMetadata
        {
            [Display(Name ="Loại Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TENLOAI { get; set; }
        }
    }
}