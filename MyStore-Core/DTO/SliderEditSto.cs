using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.DTO
{
    public class SliderEditSto
    {
        public string? DiscountTitle { get; set; }
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
