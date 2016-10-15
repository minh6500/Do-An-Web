using System.ComponentModel.DataAnnotations;

namespace LinhKienMayTinh.Models
{
    public class LienHe
    {
        [Display(Name ="Tên của bạn")]
        [Required(ErrorMessage ="Không được để trống")]
        public string UserName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage ="Không được để trống")]
        [EmailAddress(ErrorMessage ="Email không chính xác")]
        public string Email { get; set; }

        [Display(Name ="Chủ đề")]
        [Required(ErrorMessage ="Chủ đề không được để trống")]
        public string ChuDe { get; set; }

        [Display(Name ="Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [DataType(DataType.MultilineText)]
        public string NoiDung { get; set; }
    }
}