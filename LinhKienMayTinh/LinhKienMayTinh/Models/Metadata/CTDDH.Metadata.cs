using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiet ke Metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(CTDDHMetadata))]
    public partial class CTDDH
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class CTDDHMetadata
        {
            
            [Display(Name ="Mã Đơn Hàng")]
            public int MAD { get; set; }

            [Display(Name ="Đơn Giá")]
            public Nullable<int> DONGIA { get; set; }

            [Display(Name ="Số Lượng")]
            public Nullable<int> SOLUONG { get; set; }
        }
    }
}