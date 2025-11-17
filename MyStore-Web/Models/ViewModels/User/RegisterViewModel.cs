using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels.User
{
    public class RegisterViewModel
    {
        [Display(Name = " نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; } = null!;

        [Display(Name = " ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا یک {0} معتبر وارد کنید ")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = " رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمات عبور باهم تطابق ندارند")]
        [Display(Name = " تکرار رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RePassword { get; set; } = null!;
    }
}
