using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(NSXMetadata))]
    public partial class NSX
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class NSXMetadata
        {
            [Display(Name = "Nhà Sản Xuất")]
            public string TENNSX { get; set; }
        }
    }
}