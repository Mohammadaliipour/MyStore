using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels.Role
{
    public class RoleCreateViewModel
    {
        [Display(Name ="")]
        [Required(ErrorMessage ="لطفا {0}را وارد کنید")]
        public int Roleid { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        public string RoleTitle { get; set; } = null!;

        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        public string RoleName { get; set; } = null!;

    }
}
