using MyStore_Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Interfaces
{
    public interface ISliderServicess
    {

        Task<SliderDto> GetSliderbyid(int id);
        Task<List<SliderDto>> GettAllSlider();
        Task CreateSlider(SlidereditDto dto);
        Task EditSlider(SliderEditDto dto);
    }
}
