using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels
{
    public class SliderViewModel
    {
        
        public int SliderId { get; set; }

        [Display(Name =" عنوان تخفیف")]
        public string? DiscountTitle { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; } = null!;

        [Display(Name = "تصویر")]
        public string ImageName { get; set; } = null!;


        [Display(Name = "تاریخ شروع")]
        [DisplayFormat(DataFormatString ="{0:yyyy/mm/dd}",ApplyFormatInEditMode = true)]
        public DateTime Startdate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime Enddate { get; set; }


        [Display(Name = "فعال/غیرفعال بودن")]
        public bool IsActive { get; set; }
    }
}
