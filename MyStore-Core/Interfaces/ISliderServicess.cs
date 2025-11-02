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

        Task<SliderDto> GetSliderDto(int id);
    }
}
