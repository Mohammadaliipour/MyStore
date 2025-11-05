using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels
{
    public class SliderEditViewModel
    {
        public int SliderId { get; set; }

        [Display(Name = " عنوان تخفیف")]
        public string? DiscountTitle { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; } = null!;

        public IFormFile? Imagefile { get; set; } = null!;


        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        public DateTime Startdate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Enddate { get; set; }


        [Display(Name = "فعال/غیرفعال بودن")]
        [Required(ErrorMessage = "لطفا {0} را مشخص کنید")]
        public bool IsActive { get; set; }
    }
}
