using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels.Role
{
    public class RoleCreateViewModel
    {
        [Display(Name ="آیدی نقش")]
        [Required(ErrorMessage ="لطفا {0}را وارد کنید")]
        public int Roleid { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        public string RoleTitle { get; set; } = null!;

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        public string RoleName { get; set; } = null!;

    }
}
