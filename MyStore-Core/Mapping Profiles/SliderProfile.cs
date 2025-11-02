using AutoMapper;
using MyStore_Core.DTO;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Mapping_Profiles
{
    public class SliderProfile:Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider,SliderDto>().ReverseMap();
           
            
        }
    }
}
