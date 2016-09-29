using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    [MetadataTypeAttribute(typeof(KHUYENMAIMetadata))]
    public partial class KHUYENMAI
    {
        //chỉ sử dụng cho 1 class này không cho kế thừa
        internal sealed class KHUYENMAIMetadata
        {
            [Display(Name = "Khuyến Mãi")]
            public string TENKM { get; set; }


        }
    }
}